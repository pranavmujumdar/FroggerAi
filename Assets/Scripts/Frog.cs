using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class Frog : Agent
{

    public Rigidbody2D rb;
    ScoreUpdater scoreUpdater;
    Vector3 startPos;
    public override void Initialize()
    {
        scoreUpdater = GetComponent<ScoreUpdater>();
        startPos = transform.position;
    }
/*
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
            moveRight();
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            moveLeft();
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            moveUp();
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            moveDown();

    }
*/
    public override void OnActionReceived(float[] vectorAction)
    {
        int Xaction = Mathf.FloorToInt(vectorAction[0]);
        int Yaction = Mathf.FloorToInt(vectorAction[1]);

        if(Xaction == 0)
        {

        }
        if(Xaction == 1)
        {
            moveLeft();
        }
        if(Xaction == 2)
        {
            moveRight();
        }
        if(Yaction == 0)
        {

        }
        if(Yaction == 1)
        {
            moveUp();
        }
        if(Yaction == 2)
        {
            moveDown();
        }
    }

    public override void Heuristic(float[] actionsOut)
    {
        
        var Xinput = Input.GetAxisRaw("Horizontal");
        var Yinput = Input.GetAxisRaw("Vertical");

        if (Xinput == 0)
        {
            actionsOut[0] = 0;
        }
        if (Xinput < 0)
        {
            actionsOut[0] = 1;
        }
        if (Xinput > 0)
        {
            actionsOut[0] = 2;
        }

        if (Yinput == 0)
        {
            actionsOut[1] = 0;
        }
        if (Yinput < 0)
        {
            actionsOut[1] = 2;
        }
        if (Yinput > 0)
        {
            actionsOut[1] = 1;
        }
        /*
        if (Input.GetKeyDown(KeyCode.RightArrow))
            actionsOut[0] = 2;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            actionsOut[0] = 1;
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            actionsOut[1] = 1;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            actionsOut[1] = 2;
        */    

    }

    public override void OnEpisodeBegin()
    {
        transform.position = startPos;
        scoreUpdater.resetScore();
        resetFrog();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Car")
        {
            Died();
        }
        if(col.tag == "Goal")
        {
            Scored();
        }
    }

    public void Died()
    {
        Debug.Log("Died");
        AddReward(-1f);
        EndEpisode();
    }

    public void Scored()
    {
        Debug.Log("Scored");
        AddReward(2f);
        scoreUpdater.scored();
        resetFrog();
    }

    void resetFrog()
    {
        transform.position = startPos;
    }

    void moveUp()
    {
        rb.MovePosition(rb.position + Vector2.up);
    }

    void moveDown()
    {
        if(transform.position.y > startPos.y)
        {
            rb.MovePosition(rb.position + Vector2.down);
        }
    }

    void moveLeft()
    {
        if(transform.position.x > startPos.x - 3)
        {
            rb.MovePosition(rb.position + Vector2.left);
        }
    }

    void moveRight()
    {
        if(transform.position.x < startPos.x + 3)
        {
            rb.MovePosition(rb.position + Vector2.right);
        }
    }

}
