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

public abstract class Field
{
    private Field _up;
    private Field _right;
    private Field _down;
    private Field _left;
    private Pion _pion;
    private string _letter;
    private bool _isInTown;

    public Boolean IsInTown
    {
        get { return _isInTown; }
        set { _isInTown = value; }
    }

   public String Letter
    {
        get { return _letter; }
        set { _letter = value; }
    }

    public Pion Pion
    {
        get;
        set;
    }

    public void SetPion(Pion pion)
    {
        Pion = pion;

        if (pion == null) return;

        Pion.Field = this;
    }

    public Field Up
    {
        get
        {
            return _up;
        }
        set
        {
            value._down = this;
            _up = value;
        }
    }

    public Field Right
    {
        get
        {
            return _right;
        }
        set
        {
            value._left = this;
            _right = value;
        }
    }

    public Field Down
    {
        get
        {
            return _down;
        }
        set
        {
            value._up = this;
            _down = value;
        }
    }

    public Field Left
    {
        get
        {
            return _left;
        }
        set
        {
            value._right = this;
            _left = value;
        }
    }
    
}

