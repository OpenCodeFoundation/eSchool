using System;
using System.Linq;
using System.Reflection;

namespace eSchool.Core.DataDefination.PrimeEntities
{
    public abstract class IEntity
    {
        public string Id { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreateDate { get; set; }        
        public virtual DateTime LastUpdateDate { get; set; }
        public virtual string LastUpdatedBy { get; set; }
        public string[] RolesAllowedToRead { get; set; }
        public string[] IdsAllowedToRead { get; set; }
        public string[] RolesAllowedToWrite { get; set; }
        public string[] IdsAllowedToWrite { get; set; }
        public string[] RolesAllowedToUpdate { get; set; }
        public string[] IdsAllowedToUpdate { get; set; }
        public string[] RolesAllowedToDelete { get; set; }
        public string[] IdsAllowedToDelete { get; set; }

        public override int GetHashCode()
        {
            PropertyInfo[] allProperties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            PropertyInfo[] baseProperties = GetType().BaseType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var onlyChildInfos = allProperties.Where(r => !baseProperties.Any(x => x.Name == r.Name));

            unchecked
            {
                int result = 0;
                foreach (var prop in onlyChildInfos)
                {
                    var val = prop.GetValue(this);
                    if (val != null)
                        result = (result * 397) ^ val.GetHashCode();
                }
                return result < 0 ? result * -1 : result;
            }
        }
    }
}
