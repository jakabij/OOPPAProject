using System;
using System.Collections.Generic;
using System.Text;

namespace OOPPAProject
{
    interface ILoader
    {
        Store LoadFromXml(string path);
    }
}
