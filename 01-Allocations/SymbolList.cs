using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 
 * (c) Florian Rappl, 2012-2013.
 * 
 * This work is a demonstration for training purposes and may be used freely for private purposes.
 * Usage for business training / workshops is prohibited without explicit permission from the author.
 * 
 */

namespace Performance
{
    class SymbolList
    {
        #region Members, ctor und Initializer

        List<Symbol> symbols;

        public SymbolList()
        {
            symbols = new List<Symbol>();
        }

        public void LoadDefaultSymbols()
        {
            symbols.Add(new Symbol { Name = "public" });
            symbols.Add(new Symbol { Name = "internal" });
            symbols.Add(new Symbol { Name = "private" });
            symbols.Add(new Symbol { Name = "string" });
            symbols.Add(new Symbol { Name = "int" });
            symbols.Add(new Symbol { Name = "double" });
            symbols.Add(new Symbol { Name = "short" });
            symbols.Add(new Symbol { Name = "char" });
            symbols.Add(new Symbol { Name = "float" });
            symbols.Add(new Symbol { Name = "long" });
            symbols.Add(new Symbol { Name = "decimal" });
            symbols.Add(new Symbol { Name = "class" });
            symbols.Add(new Symbol { Name = "structure" });
            symbols.Add(new Symbol { Name = "foreach" });
            symbols.Add(new Symbol { Name = "enum" });
            symbols.Add(new Symbol { Name = "while" });
            symbols.Add(new Symbol { Name = "delegate" });
            symbols.Add(new Symbol { Name = "interface" });
        }

        #endregion

        #region Problem

        public Symbol FindMatchingSymbolLinq(String name)
        {
            return symbols.FirstOrDefault(s => s.Name == name);
        }

        #endregion

        #region Lösung

        public Symbol FindMatchingSymbolFixed(String name)
        {
            foreach (var symbol in symbols)
                if (symbol.Name == name)
                    return symbol;

            return null;
        }

        #endregion
    }
}
