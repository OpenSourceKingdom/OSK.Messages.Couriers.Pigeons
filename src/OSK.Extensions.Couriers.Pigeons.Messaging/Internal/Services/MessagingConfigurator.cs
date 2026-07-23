using OSK.Extensions.Couriers.Pigeons.Messaging.Ports;
using OSK.Messages.Couriers.Pigeons.Options;
using OSK.Messages.Messaging.Ports;
using System;

namespace OSK.Extensions.Couriers.Pigeons.Messaging.Internal.Services;

internal class MessagingConfigurator : IPigeonMessagingConfigurator
{
    #region Variables

    internal Action<IMessageCenterBuilder>? MessageCenterConfigurator { get; private set; }
    internal Action<PigeonOptions> OptionsConfigurator { get; private set; } = _ => { };

    #endregion

    #region IPigeonMessagingConfigurator

    public IPigeonMessagingConfigurator ConfigureMessageCenter(Action<IMessageCenterBuilder> builderConfiguration)
    {
        MessageCenterConfigurator = builderConfiguration ?? throw new ArgumentNullException(nameof(builderConfiguration));

        return this;
    }

    public IPigeonMessagingConfigurator ConfigurePigeons(Action<PigeonOptions> optionsConfigurator)
    {
        if (optionsConfigurator is not null)
        {
            OptionsConfigurator = optionsConfigurator;
        }

        return this;
    }

    #endregion

    #region Helpers

    internal void Validate()
    {
        if (MessageCenterConfigurator is null)
        {
            throw new ArgumentNullException(nameof(MessageCenterConfigurator), "Message Center configuration must be set.");
        }
    }

    #endregion
}
