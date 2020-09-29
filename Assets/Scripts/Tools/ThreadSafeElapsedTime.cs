using System.Diagnostics;

/// <summary>
/// 线程安全的时间流逝类
/// 从游戏运行开始计时
/// </summary>
public static class ThreadSafeElapsedTime
{
    private static bool _isStart = false;
    private static Stopwatch _stopwatch;
    private static long _curRawElapsedTicks;
    private static int _curRawElapsedSeconds;
    
        
    //必须在启动后调用
    public static void Start()
    {
        if (!_isStart)
        {
            _isStart = true;
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            _curRawElapsedTicks = 0;
            _curRawElapsedSeconds = 0;
        }
    }

    public static void Stop()
    {
        if (_isStart)
        {
            _isStart = false;
            _stopwatch.Stop();
        }
    }

    public static void Update()
    {
        if (_isStart)
        {
            _curRawElapsedTicks = _stopwatch.ElapsedTicks;
            _curRawElapsedSeconds = (int)(_curRawElapsedTicks / System.TimeSpan.TicksPerSecond);
        }
    }

    /// <summary>
    /// 自游戏启动以来的ticks
    /// </summary>
    /// <returns></returns>
    public static long GetElapsedTicksSinceStartUp()
    {
        #if UNITY_EDITOR
        Start();
        Update();
        #endif
        return _curRawElapsedTicks;
    }
    /// <summary>
    /// 自游戏启动以来的seconds
    /// </summary>
    /// <returns></returns>
    public static int GetElapsedSecondsSinceStartUp()
    {
#if UNITY_EDITOR
        Start();
        Update();
#endif
        return _curRawElapsedSeconds;
    }
    
    /// <summary>
    /// 自游戏启动以来的miniseconds
    /// </summary>
    /// <returns></returns>
    public static int GetElapsedMiniSecondsSinceStartUp()
    {
#if UNITY_EDITOR
        Start();
        Update();
#endif
        return _curRawElapsedSeconds * 1000;
    }
}
