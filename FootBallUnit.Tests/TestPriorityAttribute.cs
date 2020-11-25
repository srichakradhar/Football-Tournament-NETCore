using System;

namespace FootBallUnit.Tests
{
    public class TestPriorityAttribute : Attribute
{
    public TestPriorityAttribute(int priority)
    {
        Priority = priority;
    }

    public int Priority { get; private set; }
    
        
    }
}