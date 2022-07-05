using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// using static SC_SlidingDoor;

public class MathGen : MonoBehaviour
{
    // public GameObject Answer3;
    // private int choicemade;

    //maakt de range voor het antwoord
    private int randomint;
    private int randomint2;

    //assigned objects waarbij de sommen/antwoorden zichtbaar zijn
    [SerializeField] private TextMeshPro Question;
    [SerializeField] private TextMeshPro Answer1;
    [SerializeField] private TextMeshPro Answer2;
    [SerializeField] private TextMeshPro Answer3;

    //setted bools for identifying which block got shot
    public bool answer1_bool = false;
    public bool answer2_bool = false;
    public bool answer3_bool = false;

    //setted bools alongside with their values
    [SerializeField] private bool correct = false;

    ResultGen resultgen; //1st name is the script name & the 2nd one is the defined name
    public TextMeshPro display;

    void Awake()
    {
        QuestionGenerator();

        //get script
        //resultgen = display.GetComponent<ResultGen>();
    }

    private void QuestionGenerator()
    {
        {
            string[] symbol = new string[] { "+", "-"//, "x", "/" 
        };

            string randomSymbol = symbol[Random.Range(0, symbol.Length)];

            Debug.Log(randomSymbol);

            if (randomSymbol == "+")
            {
                int firstNumber = Random.Range(1, 101);
                int secondNumber = Random.Range(1, 101);
                Question.text = firstNumber.ToString() + "  +  " + secondNumber.ToString() + "  =  ?";
                int result = firstNumber + secondNumber;
                int random = Random.Range(1, 3);

                int first = result - 5;
                int second = result + 5;

                if (random == 1)
                {
                    randomint = Random.Range(first, second);
                    randomint2 = Random.Range(first, second);
                    Answer1.SetText(result.ToString());
                    Answer2.SetText(randomint2.ToString());
                    Answer3.SetText(randomint.ToString());

                    while (randomint == result) ;
                    {
                        randomint = Random.Range(first, second);
                    }

                    SubmitChecker(result, randomint2, randomint, result);
                }
                else if (random == 2)
                {
                    randomint = Random.Range(first, second);
                    randomint2 = Random.Range(first, second);
                    Answer1.SetText(randomint.ToString());
                    Answer2.SetText(result.ToString());
                    Answer3.SetText(randomint2.ToString());

                    while (randomint == result) ;
                    {
                        randomint = Random.Range(first, second);
                    }

                    SubmitChecker(randomint, result, randomint2, result);
                }
                else if (random == 3)
                {
                    randomint = Random.Range(first, second);
                    randomint2 = Random.Range(first, second);
                    Answer1.SetText(randomint.ToString());
                    Answer2.SetText(randomint2.ToString());
                    Answer3.SetText(result.ToString());

                    while (randomint == result) ;
                    {
                        int randomint = Random.Range(first, second);
                    }

                    SubmitChecker(randomint, randomint2, result, result);
                }

            }
            else if (randomSymbol == "-")
            {
                int firstNumber = Random.Range(1, 101);
                int secondNumber = Random.Range(1, 101);
                Question.text = firstNumber.ToString() + "  -  " + secondNumber.ToString() + "  =  ?";
                int result = firstNumber - secondNumber;
                int random = Random.Range(1, 3);
                int first = result - 5;
                int second = result + 5;

                if (random == 1)
                {
                    randomint = Random.Range(first, second);
                    randomint2 = Random.Range(first, second);
                    Answer1.SetText(result.ToString());
                    Answer2.SetText(randomint2.ToString());
                    Answer3.SetText(randomint.ToString());

                    while (randomint == result);
                    {
                        randomint = Random.Range(first, second);
                    }
                    SubmitChecker(result, randomint2, randomint, result);
                }
                else if (random == 2)
                {
                    randomint = Random.Range(first, second);
                    randomint2 = Random.Range(first, second);
                    Answer1.SetText(randomint.ToString());
                    Answer2.SetText(result.ToString());
                    Answer3.SetText(randomint2.ToString());

                    while (randomint == result) ;
                    {
                        randomint = Random.Range(first, second);
                    }

                    SubmitChecker(randomint, result, randomint2, result);
                }
                else if(random == 3)
                {
                    randomint = Random.Range(first, second);
                    randomint2 = Random.Range(first, second);
                    Answer1.SetText(randomint.ToString());
                    Answer2.SetText(randomint2.ToString());
                    Answer3.SetText(result.ToString());

                    while (randomint == result) ;
                    {
                        int randomint = Random.Range(first, second);
                    }

                    SubmitChecker(randomint, randomint2, result, result);
                }
            }
            //else if (randomSymbol == "x")
            //{
            //    int firstNumber = Random.Range(1, 101);
            //    int secondNumber = Random.Range(1, 101);
            //    Question.text = firstNumber.ToString() + "  x  " + secondNumber.ToString() + "  =  ?";
            //    int result = firstNumber * secondNumber;
            //    int random = Random.Range(1, 3);
            //    int first = result - 5;
            //    int second = result + 5;

            //    if (random == 1)
            //    {
            //        randomint = Random.Range(first, second);
            //        randomint2 = Random.Range(first, second);
            //        Answer1.SetText(result.ToString());
            //        Answer2.SetText(randomint2.ToString());
            //        Answer3.SetText(randomint.ToString());

            //        while (randomint == result) ;
            //        {
            //            randomint = Random.Range(first, second);
            //        }
            //        SubmitChecker(result, randomint2, randomint, result);
            //    }
            //    else if (random == 2)
            //    {
            //        randomint = Random.Range(first, second);
            //        randomint2 = Random.Range(first, second);
            //        Answer1.SetText(randomint.ToString());
            //        Answer2.SetText(result.ToString());
            //        Answer3.SetText(randomint2.ToString());

            //        while (randomint == result) ;
            //        {
            //            randomint = Random.Range(first, second);
            //        }

            //        SubmitChecker(randomint, result, randomint2, result);
            //    }
            //    else if (random == 3)
            //    {
            //        randomint = Random.Range(first, second);
            //        randomint2 = Random.Range(first, second);
            //        Answer1.SetText(randomint.ToString());
            //        Answer2.SetText(randomint2.ToString());
            //        Answer3.SetText(result.ToString());

            //        while (randomint == result) ;
            //        {
            //            int randomint = Random.Range(first, second);
            //        }

            //        SubmitChecker(randomint, randomint2, result, result);
            //    }
            //}
            //else if (randomSymbol == "/")
            //{
            //    int firstNumber = Random.Range(1, 101);
            //    int secondNumber = Random.Range(1, 101);
            //    Question.text = firstNumber.ToString() + "  /  " + secondNumber.ToString() + "  =  ?";
            //    int result = firstNumber / secondNumber;
            //    int random = Random.Range(1, 3);
            //    int first = result - 5;
            //    int second = result + 5;

            //    if (random == 1)
            //    {
            //        randomint = Random.Range(first, second);
            //        randomint2 = Random.Range(first, second);
            //        Answer1.SetText(result.ToString());
            //        Answer2.SetText(randomint2.ToString());
            //        Answer3.SetText(randomint.ToString());

            //        while (randomint == result) ;
            //        {
            //            randomint = Random.Range(first, second);
            //        }
            //        SubmitChecker(result, randomint2, randomint, result);
            //    }
            //    else if (random == 2)
            //    {
            //        randomint = Random.Range(first, second);
            //        randomint2 = Random.Range(first, second);
            //        Answer1.SetText(randomint.ToString());
            //        Answer2.SetText(result.ToString());
            //        Answer3.SetText(randomint2.ToString());

            //        while (randomint == result) ;
            //        {
            //            randomint = Random.Range(first, second);
            //        }

            //        SubmitChecker(randomint, result, randomint2, result);
            //    }
            //    else if (random == 3)
            //    {
            //        randomint = Random.Range(first, second);
            //        randomint2 = Random.Range(first, second);
            //        Answer1.SetText(randomint.ToString());
            //        Answer2.SetText(randomint2.ToString());
            //        Answer3.SetText(result.ToString());

            //        while (randomint == result) ;
            //        {
            //            int randomint = Random.Range(first, second);
            //        }

            //        SubmitChecker(randomint, randomint2, result, result);
            //    }
            //}
        }
    }

    public void SubmitChecker(int a1, int a2, int a3, int answer)
    {
    }
}
//}
//}


