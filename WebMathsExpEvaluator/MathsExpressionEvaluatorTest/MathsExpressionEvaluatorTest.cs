﻿using System;
using System.Globalization;
using System.Threading;
using MathsExpressionEvaluator;
using NUnit.Framework;

namespace SimpleExpressionEvaluator.Tests
{
    public class ExpressionEvaluatorTests
    {
        private ExpressionEvaluator engine;
        private Random generator;

        [OneTimeSetUp]
        public void SetUp()
        {
            engine = new ExpressionEvaluator();
            generator = new Random();
        }

        [Test]
        public void Empty_String_Is_Zero()
        {
            Assert.That(engine.Evaluate(""), Is.EqualTo(0));
        }

        [Test]
        public void Decimal_Is_Treated_As_Decimal()
        {
            var left = generator.Next(1, 100);

            Assert.That(engine.Evaluate(left.ToString()), Is.EqualTo(left));
        }

        [Test]
        public void Two_Plus_Two_Is_Four()
        {
            Assert.That(engine.Evaluate("2+2"), Is.EqualTo(4));
        }

        [Test]
        public void Can_Add_Two_Decimal_Numbers()
        {
            Assert.That(engine.Evaluate("2.7+3.2"), Is.EqualTo(2.7m + 3.2m));
        }

        [Test]
        public void Can_Add_Many_Numbers()
        {
            Assert.That(engine.Evaluate("1.2+3.4+5.6+7.8"), Is.EqualTo(1.2m + 3.4m + 5.6m + 7.8m));
            Assert.That(engine.Evaluate("1.7+2.9+14.24+6.58"), Is.EqualTo(1.7m + 2.9m + 14.24m + 6.58m));
        }

        [Test]
        public void Can_Subtract_Two_Numbers()
        {
            Assert.That(engine.Evaluate("5-2"), Is.EqualTo(5 - 2));
        }

        [Test]
        public void Can_Subtract_Multiple_Numbers()
        {
            Assert.That(engine.Evaluate("15.2-2.3-4.8-0.58"), Is.EqualTo(15.2m - 2.3m - 4.8m - 0.58m));
        }

        [Test]
        public void Can_Add_And_Subtract_Multiple_Numbers()
        {
            Assert.That(engine.Evaluate("15+8-4-2+7"), Is.EqualTo(15 + 8 - 4 - 2 + 7));
            Assert.That(engine.Evaluate("17.89-2.47+7.16"), Is.EqualTo(17.89m - 2.47m + 7.16m));

        }

        [Test]
        public void Can_Add_Subtract_Multiply_Divide_Multiple_Numbers()
        {
            Assert.That(engine.Evaluate("50-5*3*2+7"), Is.EqualTo(50 - 5 * 3 * 2 + 7));
            Assert.That(engine.Evaluate("84+15+4-4*3*9+24+4-54/3-5-7+47"), Is.EqualTo(84 + 15 + 4 - 4 * 3 * 9 + 24 + 4 - 54 / 3 - 5 - 7 + 47));
            Assert.That(engine.Evaluate("50-48/4/3+7*2*4+2+5+8"), Is.EqualTo(50 - 48 / 4 / 3 + 7 * 2 * 4 + 2 + 5 + 8));
            Assert.That(engine.Evaluate("5/2/2+1.5*3+4.58"), Is.EqualTo(5 / 2m / 2m + 1.5m * 3m + 4.58m));
            Assert.That(engine.Evaluate("25/3+1.34*2.56+1.49+2.36/1.48"), Is.EqualTo(25 / 3m + 1.34m * 2.56m + 1.49m + 2.36m / 1.48m));
            Assert.That(engine.Evaluate("2*3+5-4-2*5+7"), Is.EqualTo(2 * 3 + 5 - 4 - 2 * 5 + 7));
        }

        [Test]
        public void Supports_SimpleParentheses()
        {
            Assert.That(engine.Evaluate("2*(5+3)"), Is.EqualTo(2 * (5 + 3)));
            Assert.That(engine.Evaluate("(5+3)*2"), Is.EqualTo((5 + 3) * 2));
            Assert.That(engine.Evaluate("(5+3)*5-2"), Is.EqualTo((5 + 3) * 5 - 2));
            Assert.That(engine.Evaluate("(5+3)*(5-2)"), Is.EqualTo((5 + 3) * (5 - 2)));           
        }

        [Test]
        public void Execption_ForNestedParentheses()
        {

            try
            {
                var mathExpValue = engine.Evaluate("2*((5+3)*9)");
            }
            catch(Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Sorry this is too complex"));
            }
           
           
        }







    }
}
