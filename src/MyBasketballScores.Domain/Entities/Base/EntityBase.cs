using Flunt.Notifications;
using System;

namespace YouLearn.Domain.Entities.Base
{
    public abstract class EntityBase : Notifiable
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; private set; }
    }
}
