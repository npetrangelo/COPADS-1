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
    public void TestInvalidMode() {
        string[] args = {"foo", "~"};
        Assert.Throws<InvalidInputException>(() => Program.ParseArgs(args));
    }
    
    [Test]
    public void TestInvalidPath() {
        string[] args = {"-s", "~/bananas/"};
        Assert.Throws<Exception>(() => Program.ParseArgs(args));
    }
    
    [Test]
    public void TestSequential() {
        Program.Do(Program.Sequential, ".");
        Assert.Greater(Program.spanSeconds, 0.0);
        Assert.Greater(Program.numFolders, 0.0);
        Assert.Greater(Program.numFiles, 0.0);
        Assert.Greater(Program.numBytes, 0.0);

    }
    
    [Test]
    public void TestDistributed() {
        Program.Do(Program.Distributed, ".");
        Assert.Greater(Program.spanSeconds, 0.0);
        Assert.Greater(Program.numFolders, 0.0);
        Assert.Greater(Program.numFiles, 0.0);
        Assert.Greater(Program.numBytes, 0.0);
    }
}