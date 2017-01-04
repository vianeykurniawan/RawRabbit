﻿using System;
using System.Threading;
using RawRabbit.Configuration.Consumer;

namespace RawRabbit.Pipe
{
	public static class AddPropertyPipeContextExtensions
	{
		public static IPipeContext ConsumerConcurrency(this IPipeContext context, uint concurrency)
		{
			context.Properties.TryAdd(PipeKey.ConsumeSemaphore, new SemaphoreSlim((int)concurrency));
			return context;
		}

		public static IPipeContext AddConsumeSemaphore(this IPipeContext context, SemaphoreSlim semaphore)
		{
			context.Properties.TryAdd(PipeKey.ConsumeSemaphore, semaphore);
			return context;
		}

		public static IPipeContext ConsumerConfiguration(this IPipeContext context, Action<IConsumerConfigurationBuilder> configuration)
		{
			context.Properties.Add(PipeKey.ConfigurationAction, configuration);
			return context;
		}
	}
}