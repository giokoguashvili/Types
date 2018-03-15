using System;
using Types.Union;

namespace Types
{
    public class Code { }
    public class CompileError { }
    public class CompiledCode : Either<Code, CompileError>
    {
        public CompiledCode(string codeTemplate) : base(() =>
        {
            var co = codeTemplate.ToString();
            return new CompiledCode(new Code());
        }) {}

        protected CompiledCode(Code t1) : base(t1) {}
        protected CompiledCode(CompileError t2) : base(t2) {}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Union<Code, CompileError> vax = new Union<Code, CompileError>(new Code());
            Union<Code, CompileError> vax1 = new CompiledCode("asd");

            var x = new CompiledCode("asdf")
                .Match(
                    (cc) => cc.ToString(),
                    (e) => e.ToString()
                );
            Console.WriteLine("Hello World!");
        }
    }
}
