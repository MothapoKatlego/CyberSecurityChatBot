using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

public class QuizQuestion
{
    public string Question { get; set; }
    public List<string> Options { get; set; }
    public string Answer { get; set; }
    public string Explanation { get; set; }

    // Parameterless constructor required for object initializers
    public QuizQuestion() { }
}

