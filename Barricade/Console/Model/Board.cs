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

public class Board
{
	public virtual IEnumerable<Field> Field
	{
		get;
		set;
	}

	public virtual Town Town
	{
		get;
		set;
	}

	public virtual ForestField ForestField
	{
		get;
		set;
	}

	public virtual List<Barricade> Barricade
	{
		get;
		set;
	}

	public virtual List<RedPion> RedPion
	{
		get;
		set;
	}

	public virtual List<GreenPion> GreenPion
	{
		get;
		set;
	}

	public virtual List<YellowPion> YellowPion
	{
		get;
		set;
	}

	public virtual List<BluePion> BluePion
	{
		get;
		set;
	}

    public Field Origin
    {
        get;
        set;
    }

    public Board()
    {
        BluePion = new List<BluePion>();
        BluePion.Add(new BluePion());
        BluePion.Add(new BluePion());
        BluePion.Add(new BluePion());
        BluePion.Add(new BluePion());

        YellowPion = new List<YellowPion>();
        YellowPion.Add(new YellowPion());
        YellowPion.Add(new YellowPion());
        YellowPion.Add(new YellowPion());
        YellowPion.Add(new YellowPion());

        RedPion = new List<RedPion>();
        RedPion.Add(new RedPion());
        RedPion.Add(new RedPion());
        RedPion.Add(new RedPion());
        RedPion.Add(new RedPion());

        GreenPion = new List<GreenPion>();
        GreenPion.Add(new GreenPion());
        GreenPion.Add(new GreenPion());
        GreenPion.Add(new GreenPion());
        GreenPion.Add(new GreenPion());

        Origin = new EndField();

        Field r1c1 = new RegularField();
        Field r1c2 = new RegularField();
        Field r1c3 = new RegularField();
        Field r1c4 = new RegularField();
        Field r1c5 = new RegularField();
        Field r1c6 = new RegularField();
        Field r1c7 = new RegularField();
        Field r1c8 = new RegularField();
        Field r1c9 = new RegularField();

        Origin.Down = r1c5;

        r1c1.Right = r1c2;
        r1c2.Right = r1c3;
        r1c3.Right = r1c4;
        r1c4.Right = r1c5;
        r1c5.Right = r1c6;
        r1c6.Right = r1c7;
        r1c7.Right = r1c8;
        r1c8.Right = r1c9;
    }
}

