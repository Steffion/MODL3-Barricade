﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RegularField : Field
{
    public RegularField()
    {
        Letter = "o";
    }

    public RegularField(Pion pion)
    {
        Pion = pion;
        SetPion(pion);
    }
}

