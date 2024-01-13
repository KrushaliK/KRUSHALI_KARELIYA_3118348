using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    GameObject player;

    NavMeshAgent nvagent;

    void Start()
    {
        player = FindObjectOfType<SimplePlayer>().gameObject;
        nvagent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nvagent.SetDestination(player.transform.position);
    }
}
