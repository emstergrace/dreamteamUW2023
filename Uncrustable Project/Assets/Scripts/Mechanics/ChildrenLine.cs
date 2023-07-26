using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenLine : MonoBehaviour
{
    // https://discussions.unity.com/t/make-an-npc-follow-player-on-collision-ala-yoshi-collecting-eggs/164792/2
    public string childrenTag = "Child";
    public float followDamping = 5;
    public float followDistance = 0;
    private List<GameObject> children;
    // Start is called before the first frame update
    void Start()
    {
        children = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddChild(GameObject child){
    {
        // Add a joint to this object.
        var j = gameObject.AddComponent<SpringJoint2D>();

        // Connect thing to the joint and set joint settings.
        j.autoConfigureConnectedAnchor = false;
        j.dampingRatio = followDamping;
        j.connectedBody = child.GetComponent<Rigidbody2D>();

        // Use fixed follow distance if set.
        if (followDistance > 0)
        {
            j.autoConfigureDistance = false;
            j.distance = followDistance;
        }

        // Add new joint to the joints list.
        joints.Add(j);

        // Add new collected thing to collection list.
        children.Add(child);
    }
}
