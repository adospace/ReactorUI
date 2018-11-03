using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Contracts
{
    public interface IMetadataProvider
    {
        void SetMetadata<T>(string key, T value);

        T GetMetadata<T>(string key, T defaultValue = default(T));

        bool ContainsMetadata(string key);
    }
}
