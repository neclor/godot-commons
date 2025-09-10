using System.Collections;
using System.Collections.Immutable;
using System.Linq;

namespace Neclor.Commons.Extensions;


public static class TypeExtensions {

#pragma warning disable CA1034, CA1822
	extension(Type t) {

		public Type[] GetBaseTypes() {
			List<Type> baseTypes = [];

			Type? type = t.BaseType;

			while (type is not null) {
				baseTypes.Add(type);
				type = type.BaseType;
			}

			return baseTypes.ToArray();
		}

		public IReadOnlyList<Type> GetAllTypes() {
			//List<Type> allTypes = [];



			return [];
			//return t.GetInterfaces().Concat(t.GetBaseTypes()).ToArray()
		}
	}
#pragma warning restore CA1034, CA1822
}
