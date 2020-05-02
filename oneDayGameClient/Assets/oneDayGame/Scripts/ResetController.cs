using UnityEngine;

public class ResetController : MonoBehaviour
{
    class StartInfo
    {
        private Rigidbody rigidbody;

        private Vector3 startPosition;

        public StartInfo(Rigidbody rigidbody)
        {
            this.rigidbody = rigidbody;
            startPosition = rigidbody.transform.position;
        }

        public void Reset()
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.transform.position = startPosition;
            rigidbody.gameObject.SetActive(true);
        }
    }

    private Rigidbody[] rigidbodies;

    private StartInfo[] startInfos;

    void Awake()
    {
        rigidbodies = FindObjectsOfType<Rigidbody>();
        startInfos = new StartInfo[rigidbodies.Length];
        for (var i = 0; i < rigidbodies.Length; i++)
        {
            startInfos[i] = new StartInfo(rigidbodies[i]);
        }
    }

    public void Reset()
    {
        foreach (var startInfo in startInfos)
        {
            startInfo.Reset();
        }
    }
}