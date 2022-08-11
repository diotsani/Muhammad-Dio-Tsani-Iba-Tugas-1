using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human
{
    public interface IHumanFactory
    {
        GameObject HumanFactoryMethod(int tag);
    }
}

