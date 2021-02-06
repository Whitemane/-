using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{

    private float previousTime;
    public float fallTime=0.8f;

    private float width = 10f;
    private float height = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1,0,0);
            if(!ValidMove())
            {
                transform.position -= new Vector3(-1,0,0);
            }
          
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
          
           
        }
        if(Time.time-previousTime>(Input.GetKeyDown(KeyCode.DownArrow)?fallTime/10:fallTime))
        {
            transform.position += new Vector3(0,-1,0);
            /*
            if (!ValidMove())  //检查每次的移动是否有效
                transform.position -= new Vector3(0,-1,0);
            */
            Debug.Log(this.transform.position.x);
            Debug.Log(this.transform.position.y);
            if(!ValidMove())
            {
                transform.position -= new Vector3(0,-1,0);
            }
            previousTime = Time.time;
        }
    }
    bool ValidMove()
    {
        foreach(Transform children in transform)
        {
            int roundedX =Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            //移动无效
            if(roundedX<0||roundedX>=width||roundedY<0||roundedY>=height)
            {
                return false;
            }
        }
        return true;
    }


}
