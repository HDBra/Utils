package iflytek.common.base;

import java.sql.*;;

/**
 * ������Ϊʹ��java�������ݿ�Ļ���
 * @author Administrator
 *
 */
public class DbHelper {

	/**
	 * ����ʵ��
	 */
	private static DbHelper dbHelper;
	/**
	 * ���ض����ݿ�����ӣ��Ự����
	 */
	private Connection conn;
	
	/**
	 * ���ݿ�������������com.mysql.jdbc.Driver
	 */
	private String driver;
	
	/**
	 * jdbc:subprotocol:subname ��ʽ�����ݿ� url
	 */
	private String url;
	
	/**
	 * �������ݿ���û���
	 */
	private String userName;
	
	/**
	 * �������ݿ������
	 */
	private String password;
	

	
	/**
	 * ˽�еĹ��캯��
	 * @throws Exception
	 */
	private DbHelper(String driver,String url,String userName,String password) throws Exception{
		this.driver = driver;
		this.url = url;
		this.userName = userName;
		this.password = password;
		//ע�����ݿ�����
		Class.forName(driver);
		this.conn = DriverManager.getConnection(url,userName,password);
	}


	/**
	 * ��ȡ����ʵ��
	 * @return
	 */
	public static DbHelper getInstance(String driver,String url,String userName,String password) throws Exception{
		if(dbHelper == null){
			dbHelper = new DbHelper(driver,url,userName,password);
		}
		
		return dbHelper;
	}


	/**
	 * ��ȡ�����ݿ�����ӣ��Ự����
	 * @return
	 * @throws Exception 
	 */
	public Connection getConn() throws Exception {
		if(conn == null){
			Class.forName(this.driver);
			conn = DriverManager.getConnection(url,userName,password);
		}
		return conn;
	}

	/**
	 * ���������ݿ������
	 * @param conn
	 */
	public void setConn(Connection conn) {
		this.conn = conn;
	}

	/**
	 * ��ȡ���ݿ������ַ���
	 * @return
	 */
	public String getDriver() {
		return driver;
	}

	/**
	 * �������ݿ������ַ���
	 * @param driver
	 */
	public void setDriver(String driver) {
		this.driver = driver;
	}

	/**
	 * ��ȡ���ݿ�url
	 * @return
	 */
	public String getUrl() {
		return url;
	}

	/**
	 * �������ݿ�url
	 * @param url
	 */
	public void setUrl(String url) {
		this.url = url;
	}

	/**
	 * ��ȡ���ݿ��û���
	 * @return
	 */
	public String getUserName() {
		return userName;
	}

	/**
	 * �������ݿ��û���
	 * @param userName
	 */
	public void setUserName(String userName) {
		this.userName = userName;
	}

	/**
	 * ��ȡ���ݿ�����
	 * @return
	 */
	public String getPassword() {
		return password;
	}

	/**
	 * �������ݿ�����
	 * @param password
	 */
	public void setPassword(String password) {
		this.password = password;
	}
	
	/**
	 * ִ�в������
	 * @param sql
	 * @return �Ƿ����ɹ�
	 * @throws Exception
	 */
	public boolean insert(String sql) throws Exception{
		Statement stmt = this.conn.createStatement();
		if(stmt.executeUpdate(sql) != 1){
			return false;
		}
		return true;
	}
	
	/**
	 * ִ�в�ѯ����
	 * @return
	 * @throws Exception
	 */
	public ResultSet query(String sql) throws Exception{
		Statement stmt = conn.createStatement();
		return stmt.executeQuery(sql);
	}
	
	/**
	 * ������Ӱ�������
	 * @return
	 * @throws Exception
	 */
	public int delete(String sql) throws Exception{
		Statement stmt = conn.createStatement();
		return stmt.executeUpdate(sql);
	}
	
	/**
	 * ������Ӱ�������
	 * @return
	 * @throws Exception
	 */
	public int update(String sql) throws Exception{
		Statement stmt = conn.createStatement();
		return stmt.executeUpdate(sql);
	}
}
