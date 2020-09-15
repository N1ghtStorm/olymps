using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiceBehavior : MonoBehaviour
{
    public GameObject diceObject;
    public IEnumerable<IDice> dices;
    public IDiceBag diceBag;
    private uint diceCount;


    // Start is called before the first frame update
    void Start()
    {
        //dice = new SixDice(diceObject);
        diceCount = 5;
        dices = new IDice[diceCount];

        for (var i = 0; i < dices.Count(); i ++ )
        {
            (dices as IDice[])[i] = new SixDice(diceObject);
        }
        

        diceBag = new NewYearDiceBag(dices as IDice[]);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
