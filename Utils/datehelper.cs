//���µĺ��붼�������997��������999 ��ΪSQL SERVER�ľ���Ϊ3����
//���µ�����
int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

//��������� �Ƿ�������           
int daysInYear = DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365;

//���µ�һ��
DateTime firstDayInMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
//���µ����һ�� ����1�ż�һ���µ�����1�ţ��ټ���һ����Ǳ������һ��
DateTime lastDayInMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
//�������һ�����ҹ
DateTime lastDayInMonth2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddMilliseconds(-3);

//�����һ��
DateTime firstDayInYear = new DateTime(DateTime.Now.Year, 1, 1);

//�������һ��
DateTime lastDayInYear = new DateTime(DateTime.Now.Year, 12, 31);
//�������һ�����ҹ
DateTime lastDayInYear2 = new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59, 997);

//�õ����ڼ� ������Ϊ7
int dayOfWeek = Convert.ToInt32(DateTime.Now.DayOfWeek) < 1 ? 7 : Convert.ToInt32(DateTime.Now.DayOfWeek);
//����һ
DateTime monday = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day).AddDays(1 - dayOfWeek);
//���� ������
DateTime sunday = monday.AddDays(6);
//���� ���������ҹ
DateTime sunday2 = monday.AddDays(7).AddMilliseconds(-3);

//�����ȵ�һ��
DateTime firsyDayInQuarter = new DateTime(DateTime.Now.Year, DateTime.Now.Month - (DateTime.Now.Month - 1) 

