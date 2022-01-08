using NUnit.Framework;
using OpenCartTests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace OpenCartTests.Tests.Shulga_Dmytro
{
    // TODO
    [TestFixture]
    public class FeedbackTests : TestRunner
    {
        protected override string OpenCartURL { get => "http://cart"; }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}