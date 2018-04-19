# ProjectManagerApi.Test.ProjectManagerNBench+GetAllUsersCounterThroughputBenchMark
_19-04-2018 15:39:14_
### System Info
```ini
NBench=NBench, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
OS=Microsoft Windows NT 6.2.9200.0
ProcessorCount=2
CLR=4.0.30319.42000,IsMono=False,MaxGcGeneration=2
```

### NBench Settings
```ini
RunMode=Throughput, TestMode=Measurement
NumberOfIterations=10, MaximumRunTime=00:00:10
Concurrent=False
Tracing=False
```

## Data
-------------------

### Totals
|          Metric |           Units |             Max |         Average |             Min |          StdDev |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|[Counter] AddCounter |      operations |        1,239.00 |        1,239.00 |        1,239.00 |            0.00 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|[Counter] AddCounter |      operations |        1,481.85 |        1,262.80 |          741.47 |          249.78 |

### Raw Data
#### [Counter] AddCounter
|           Run # |      operations |  operations / s | ns / operations |
|---------------- |---------------- |---------------- |---------------- |
|               1 |        1,239.00 |        1,467.96 |     6,81,215.50 |
|               2 |        1,239.00 |        1,198.29 |     8,34,524.46 |
|               3 |        1,239.00 |        1,393.53 |     7,17,604.04 |
|               4 |        1,239.00 |          741.47 |    13,48,666.51 |
|               5 |        1,239.00 |        1,393.62 |     7,17,553.91 |
|               6 |        1,239.00 |        1,481.85 |     6,74,832.20 |
|               7 |        1,239.00 |        1,351.29 |     7,40,033.74 |
|               8 |        1,239.00 |          893.12 |    11,19,665.38 |
|               9 |        1,239.00 |        1,367.38 |     7,31,326.55 |
|              10 |        1,239.00 |        1,339.46 |     7,46,571.51 |


