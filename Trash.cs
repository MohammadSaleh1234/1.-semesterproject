using System;
using System.Collections.Generic;

// ====================================================================
// 1. TRASH DATAKLASSEN (NY)
//    Definerer strukturen for et stykke affald
// ====================================================================
public class Trash
{
    public string Name { get; }
    public string Description { get; }
    public string FunFact { get; }

    public Trash(string name, string description, string funFact)
    {
        Name = name;
        Description = description;
        FunFact = funFact;
    }
}

