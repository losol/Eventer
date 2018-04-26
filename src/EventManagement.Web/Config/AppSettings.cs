﻿using System;
namespace losol.EventManagement.Config
{
	internal class AppSettings
	{
		public EmailProvider EmailProvider { get; set; }
		public SmsProvider SmsProvider { get; set; }
		public bool UsePowerOffice { get; set; }
	}

	internal enum EmailProvider 
	{
		SendGrid,
		SMTP,
		File,
		Mock
	}

	internal enum SmsProvider
	{
		Twilio,
		Mock
	}
}