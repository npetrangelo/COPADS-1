// using Microsoft.VisualStudio.TestPlatform.TestHost;

using COPADS_1;

namespace du.Tests;

public class Tests {
    [SetUp]
    public void Setup() {
    }

    [Test]
    public void Test1() {
        Assert.Pass();
    }

    [Test]
    public void TestInvalidInput() {
        string[] args = {"foo", "~"};
        Assert.Throws<InvalidInputException>(() => Program.ParseArgs(args));
    }
}