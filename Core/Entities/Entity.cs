using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Core.Entities
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public IDictionary<string, string[]> Validate() 
        {
            var res = new Dictionary<string, string[]>();
            var ctx = new ValidationContext(this, null, null);
            var err = new List<ValidationResult>();
            Validator.TryValidateObject(this, ctx, err, true);
            foreach(var e in err)
            {
                var key = e.MemberNames.First();
                if (res.GetValueOrDefault(key) != null)
                    res[key] = res[key].Concat(new string[] { e.ErrorMessage }).ToArray();
                else res[key] = new string[] { e.ErrorMessage };
            }
            return res;
        }
    }
}
