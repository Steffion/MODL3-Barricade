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

public abstract class Pion
{
    private Field _field;
    private char _letter;
    private ConsoleColor _cColor;
    private ConsoleColor _fColor;
    private ConsoleKey _cKey;

    public Field Field
    {
        get;
        set;
    }
    public Char Letter
    {
        get
        {
            return _letter;
        }
        set
        {
            _letter = value;
        }
    }
    public ConsoleColor CColor
    {
        get
        {
            return _cColor;
        }
        set
        {
            _cColor = value;
        }
    }
    public ConsoleKey CKey
    {
        get
        {
            return _cKey;
        }
        set
        {
            _cKey = value;
        }
    }

    public void SetField(Field field)
    {
        Field = field;
        Field.Pion = this;
    }
    public void Move(Field nextField)
    {
        Field.SetPion(null);
        SetField(nextField);
    }

    public void MoveOverPion(Pion pion, Field nextField)
    {
        Field.SetPion(pion);
        SetField(nextField);
    }
}

