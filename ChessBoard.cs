using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChessBoard : MonoBehaviour
{
    const int BOARD_WIDTH = 8;
    const int BOARD_HEIGHT = 8;
    const int CHESS_BLACK_BACK_LAYER = 2;
    const int CHESS_BLACK_FRONT_LAYER = 2;
    int counterWhite = 0, counterBlack = 0, Checkercounter = 0, move = 1, Checkercounter1 = 0;
   // public Rigidbody checker1;

    void Start()
    {
        for (int z = 0; z <= BOARD_HEIGHT; z++)
        {
            for (int x = 0; x <= BOARD_WIDTH; x++)
            {
                GameObject square = GameObject.CreatePrimitive(PrimitiveType.Cube);
                square.transform.position += new Vector3(x, -0.5f, z);
                square.tag = "White";
                square.name = "White" + (counterWhite++);

                if ((x % 2) == (z % 2))
                {
                    square.GetComponent<Renderer>().material.color = Color.black;
                    square.tag = "Black";
                    square.name = "Black" + (counterBlack++);
                }

            }
        }
        for (int blackFront = -1; blackFront <= CHESS_BLACK_FRONT_LAYER; blackFront++)
        {
            GameObject checker1 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            checker1.transform.localScale = new Vector3(1, 0.13f, 1);
            checker1.transform.position += new Vector3(CHESS_BLACK_FRONT_LAYER * blackFront + 3, .11f, 1);


            if ((CHESS_BLACK_FRONT_LAYER % 2) == 0)
            {
                checker1.GetComponent<Renderer>().material.color = Color.black;
                checker1.tag = "CheckerFront";
                checker1.name = "CheckerFront" + (Checkercounter1++);
         //       UnityEngine.Object.Destroy(checker1.GetComponent<>());
            }
        }

        for (int black = -2; black <= CHESS_BLACK_BACK_LAYER; black++)
        {
            GameObject checker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            checker.transform.localScale = new Vector3(1, 0.13f, 1);
            checker.transform.position += new Vector3(CHESS_BLACK_BACK_LAYER * black + 4, .11f, 0);

            if ((CHESS_BLACK_BACK_LAYER % 2) == 0)
            {
                checker.GetComponent<Renderer>().material.color = Color.black;
                checker.tag = "Checker";
                checker.name = "Checker" + (Checkercounter++);
            }
        }


        for (int WhiteFront = -1; WhiteFront <= CHESS_BLACK_FRONT_LAYER; WhiteFront++)
        {
            GameObject CheckerWhiteF = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            CheckerWhiteF.transform.localScale = new Vector3(1, 0.13f, 1);
            CheckerWhiteF.transform.position += new Vector3(CHESS_BLACK_FRONT_LAYER * WhiteFront + 3, .11f, 7);


            if ((CHESS_BLACK_FRONT_LAYER % 2) == 0)
            {
                CheckerWhiteF.GetComponent<Renderer>().material.color = Color.white;
                CheckerWhiteF.tag = "CheckerFront";
                CheckerWhiteF.name = "CheckerFront" + (Checkercounter1++);
            }
        }

        for (int WhiteBack = -2; WhiteBack <= CHESS_BLACK_BACK_LAYER; WhiteBack++)
        {
            GameObject CheckerWhiteB = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            CheckerWhiteB.transform.localScale = new Vector3(1, 0.13f, 1);
            CheckerWhiteB.transform.position += new Vector3(CHESS_BLACK_BACK_LAYER * WhiteBack + 4, .11f, 8);

            if ((CHESS_BLACK_BACK_LAYER % 2) == 0)
            {
                CheckerWhiteB.GetComponent<Renderer>().material.color = Color.white;
                CheckerWhiteB.tag = "Checker";
                CheckerWhiteB.name = "Checker" + (Checkercounter++);
            }
        }
    }
}