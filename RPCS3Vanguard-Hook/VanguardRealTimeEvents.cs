﻿using RTCV.CorruptCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPCS3Vanguard_Hook
{
    class VanguardRealTimeEvents
	{
		public bool SupportsRewind { get; set; } = false;
		public bool SupportsForwarding { get; set; } = false;
		public bool SupportsFastForwarding { get; set; } = false;

		public event EventHandler<RealTimeEventArgs> StepHandler;
		public event EventHandler GameLoaded;
		public event EventHandler GameClosed;

		public void ON_STEP(bool _isForwarding, bool _isRewinding, bool _isFastForwarding)
		{
			StepHandler?.Invoke(this, new RealTimeEventArgs()
			{
				isForwarding = _isForwarding,
				isRewinding = _isRewinding,
				isFastForwarding = _isFastForwarding,
			});

		}

		public void LOAD_GAME() => GameLoaded?.Invoke(this, new EventArgs());
		public void GAME_CLOSED() => GameClosed?.Invoke(this, new EventArgs());
	}
}
