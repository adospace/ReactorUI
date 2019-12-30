using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Contracts
{
    public interface IStyle
    {
    }

    public interface IStyle<T> where T : IUIElement
    { 
    
    }
}
