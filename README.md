# WinPacketsEdit

#### 软件原作者
软件作者：RNShinoa

#### 软件介绍
C# 仿WPE封包拦截器（无需CCProxy即可拦截手游封包）

由于WPE只能用于32位软件的封包拦截，针对现在的64位手游模拟器就需要使用到32位的CCProxy等代{过}{滤}理软件，用起来很麻烦所以我就用C#自己开发了一个仿WPE的封包拦截器，可以自适应32位和64位的软件，且wpe常用的功能都有了，开发中使用了多线程技术，测试了拦截1万+的封包不会卡死或退出，软件不定期会更新功能，每次启动的时候支持在线自动更新，欢迎大家跟帖提出修改意见，谢谢！

#### 启动并注入进程

1.  双击软件图标启动程序后，会提示以管理员权限运行，点击确定后显示进程注入界面，点击 “...” 按钮选择进程<br />
![进程注入界面](https://images.gitee.com/uploads/images/2021/0601/053340_e9b02841_1232593.png "01.png")<br />
2.  选择需要拦截封包的进程名称，点击“确定”，如下面图示选择的为雷电模拟的进程<br />
![选择拦截封包的进程](https://images.gitee.com/uploads/images/2021/0601/053354_f25f642a_1232593.png "02.png")<br />
3.  选择进程后，点击 “注入” 按钮<br />
![注入进程](https://images.gitee.com/uploads/images/2021/0601/053404_9b0ccfd1_1232593.png "03.png")<br />
4.  如下图出现红框内文字时代表注入进程成功，否则会提示相关错误信息（并不是所有进程都可以实现注入，各类手游模拟器及CCProxy等代{过}{滤}理软件经测试可以成功注入）<br />
![注入进程成功](https://images.gitee.com/uploads/images/2021/0601/053413_73869b02_1232593.png "04.png")<br />
5.  成功注入进程后，即可弹出封包拦截主界面，这时候即可关闭上图的进程注入器了<br />
![封包拦截主界面](https://images.gitee.com/uploads/images/2021/0601/053422_33cdcd74_1232593.png "05.png")<br />

#### 封包拦截器的使用

封包拦截器是仿WPE的常用功能很容易上手我就不做详细的说明了，如果后期有需要的话我再补充这块的说明。


#### 更新日志

2021-6-19 发布 1.0.0.16 版本
1. “发送封包”和“发送列表”界面现在加上了注入的是哪个进程的提示了，方便大家多开使用<br />
2. 取消默认过滤的“0.0.0.0：0”封包<br />
3. 新增 “递进发送” 功能，可按照设置的递进位置和步长，自动计算数据值并修改封包内容后发送<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0619/224122_56e8e19b_1232593.jpeg "024.jpg")<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0619/224136_483dfdb3_1232593.jpeg "025.jpg")<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0619/224201_188ec2e2_1232593.jpeg "026.jpg")<br />

2021-6-12 发布 1.0.0.15 版本
1. 设置软件默认以管理员权限启动，避免出现某些闪退的情况<br />
2. 修复调试信息中出现的错误提示<br />
3. 添加 “保存此列表数据” 和 “加载发送列表” 功能，可以将发送列表中的封包数据保存到txt文本文件中，也可以从保存的文件中加载封包数据（加载封包数据后由于套接字可能已变更，请使用正确的套接字来发送，否则会出现发送失败的情况）<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0612/180307_89ac7a18_1232593.jpeg "020.jpg")<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0612/180338_87860165_1232593.jpeg "021.jpg")<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0612/180348_d160c251_1232593.jpeg "022.jpg")<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0612/180358_adff948f_1232593.jpeg "023.jpg")<br />

2021-6-10 发布 1.0.0.14 版本
1. 主界面封包信息菜单新增“查看发送列表”项，方便大家直接查看发送列表<br />
2. “发送封包”界面现在可以把修改后的封包直接“添加到发送列表”了，在封包内容文本框中点击鼠标右键可弹出此功能菜单<br />
3. "清空发送列表"功能迁移到“发送列表”的右键菜单中了<br />
4. 新增“使用此套接字”菜单功能，可使用当前选择的封包的套接字来发送列表中的所有封包，方便套接字变更后还可以继续使用原有的发送列表<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0611/075408_c63a3fa5_1232593.jpeg "017.jpg")<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0611/075421_a5f37213_1232593.jpeg "018.jpg")<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0611/075429_729f4dc3_1232593.jpeg "019.jpg")<br />

2021-6-8 发布 1.0.0.13 版本
修复默认被拦截并且不显示出来的过滤封包（0.0.0.0:0）现在可以正常显示在“已过滤”标签中了<br />
优化封包显示界面，采用异步加载和事件机制来显示封包数据，解决加载数据时界面闪烁的问题<br />
优化封包数据列的显示，大于50长度的封包现在将只显示前50个数据，完整的数据仍可以在“数据显示方式”栏查看，此调整可以加快大量封包数据的显示速度，简化显示的数据结尾会有...做标识<br />
优化所有窗口界面，可以根据操作系统的缩放比例来自动适配界面和字体大小，避免文字被覆盖的情况<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0611/054321_cb83fe3e_1232593.jpeg "010.jpg")<br />
新增“选择程序”功能，支持新打开一个程序来注入，方便从最开始拦截此程序的封包<br />
成功注入后，点击“开始”按钮，既可启动选择的程序，并开始拦截封包<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0611/054334_1b6246d3_1232593.jpeg "011.jpg")<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0611/054407_8654f7e1_1232593.jpeg "012.jpg")<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0611/054419_442217e9_1232593.jpeg "013.jpg")<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0611/054430_4408cfac_1232593.jpeg "014.jpg")<br />
新增“添加到发送列表”功能菜单，支持批量发送选择的多个封包，方便大家刷游戏任务等场景<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0611/054451_93b4a785_1232593.jpeg "015.jpg")<br />
经测试在win7 64位专业版，安装.net framework 4.0框架后可以正常使用，供大家参考<br />
![输入图片说明](https://images.gitee.com/uploads/images/2021/0611/054502_71638c06_1232593.jpeg "016.jpg")<br />

2021-6-4 发布 1.0.0.12 版本
新增在打开软件后提示当前内核的版本号，方便大家对照论坛上的更新日志<br />
![进程注入界面](https://images.gitee.com/uploads/images/2021/0605/030900_87110656_1232593.png "008.png")<br />
新增“清除数据”功能，关闭后点击开始按钮将不再清空原有的封包列表数据，此功能默认开启，可随时手动关闭<br />
调整封包发送功能，新增在封包列表中鼠标右键弹出发送菜单，点击“发送”后显示发送封包窗口，支持同时打开多个发送窗口，可分别发送不同的封包<br />
![封包拦截主界面](https://images.gitee.com/uploads/images/2021/0605/032404_d236cded_1232593.png "009.png")<br />

2021-6-2 发布 1.0.0.10 版本
修复在系统字体放大情况下部分文字被遮盖的情况<br />
新增常用按钮的快捷键，比如 “开始 (K)” 按钮的快捷键就是Alt + K，其它按钮以此类推<br />
选择进程界面现已按照进程名称首字母的顺序排列，并且可以通过按进程首字母的按键来快速定位到该名称进程的第一个，再按一下就定位到下一个，方便大家查找进程<br />
![选择进程界面](https://images.gitee.com/uploads/images/2021/0603/031256_cb213834_1232593.png "007.png")<br />

2021-5-29 发布 1.0.0.9 版本 - 修复过滤包数量统计错误问题，新增封包“拦截”功能。<br />
"拦截" 功能默认不开启，需要拦截哪种封包，就勾选哪种封包前的拦截框，封包拦截后会在“已拦截”处显示拦截的数量<br />
![封包“拦截”功能](https://images.gitee.com/uploads/images/2021/0603/031206_555b34fe_1232593.png "006.png")