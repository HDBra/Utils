package iflytek.common.base;


import java.io.UnsupportedEncodingException;

import javax.servlet.ServletContext;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

//****************************************************
//ע�����
//1����java��ʹ��/��ʾ��վ�ĸ�·������WebRoot
//2����Ҫ������web.xml������session����Ч�ڣ���������
/*
<session-config>
<!-- �Է���Ϊ��λ -->
<session-timeout>15 </session-timeout>
</session-config>
*/
/**
 * ������Ϊ��дvxml��Servlet�Ĺ�ͬ����
 */
public class BaseServlet extends HttpServlet {

	/**
	 * 
	 */
	private static final long serialVersionUID = 3322483988152568915L;

	/**
	 * ��ȡ�ļ���Ŀ¼ʵ�ʵ�·��
	 * @param mapUrl ָ������·���� String
	 * @return �ļ���Ŀ¼ʵ�ʵ�·��������޷�ִ��ת�����򷵻� null��
	 */
	public String getPath(String mapUrl){
		ServletContext app = this.getServletContext();
		return app.getRealPath(mapUrl);
	}
	
	/**
	 * ��ȡ��վ��·����ʵ��·��
	 * @return ��վ��ʵ�ʸ�·��
	 */
	public String getRootPath(){
		return getPath("/");
	}
	
	/**
	 * ʹ��ָ�����ƽ�����󶨵��˻Ự���������ͬ�����ƵĶ����Ѿ��󶨵��ûỰ�����滻�ö���
	 * @param key ��
	 * @param value ֵ
	 * 
	 */
	public void putSessionValue(HttpServletRequest request,String key,Object value){
		//��ȡ��session
		HttpSession session = request.getSession();
		session.setAttribute(key, value);
	}
	
	/**
	 * ��ȡָ�����Ƶ�session
	 * @param key ��
	 * @return ������˻Ự�е�ָ�����ư���һ��Ķ������û�ж�����ڸ������£��򷵻� null��
	 */
	public Object getSessionValueOfObject(HttpServletRequest request,String key){
		//��ȡ��session
		HttpSession session = request.getSession();
		return session.getAttribute(key);
	}
	
	/**
	 * ��ȡָ�����Ƶ�session
	 * @param key ��
	 * @return ������˻Ự�е�ָ�����ư���һ����ַ��������û���ַ������ڸ������£��򷵻� null��
	 */
	public String getSessionValueOfString(HttpServletRequest request,String key){
		Object value = getSessionValueOfObject(request,key);
		if(value == null){
			return null;
		}
		return value.toString();
	}
	
	/**
	 * �Ӵ˻Ự���Ƴ���ָ�����ư���һ��Ķ�������Ựû����ָ�����ư���һ��Ķ�����˷�����ִ���κβ�����
	 * @param key ��
	 * 
	 */
	public void clearSession(HttpServletRequest request,String key){
		//��ȡ��session
		HttpSession session = request.getSession();
	    session.removeAttribute(key);
	}
	
	/**
	 * ͨ��ȷ������ֻ��һ��ֵʱ����Ӧ��ʹ�ô˷��������������Ӧ���ֵ���Ƽ����������ĳ��򣬶����ǵ���getQueryStrings
	 * @param key ��
	 * @return �� String ��ʽ�������������ֵ������ò��������ڣ��򷵻� null��
	 */
	public String getQueryString(HttpServletRequest request,String key){
		return  request.getParameter(key);
	}
	
	/**
	 * ���Ƽ�ʹ�ø÷����������ʹ���˸÷�����������������Ƴ��򡣣���Ȼд�����������Ա��Ӧ��ʹ�ø÷�����
	 * @param request
	 * @param key
	 * @return ���ذ��������������ӵ�е�����ֵ�� String �������飬����ò��������ڣ��򷵻� null��
	 */
	public String[] getQueryStrings(HttpServletRequest request,String key){
		return request.getParameterValues(key);
	}
	
	/**
	 * ���get��post��ʽ�����Ĳ�ѯ�ַ�����������
	 * @param source
	 * @return
	 * @throws UnsupportedEncodingException 
	 */
	public String stringToGBK(String source) throws UnsupportedEncodingException{
		return new String(source.getBytes("ISO-8859-1"),"GBK");
	}
}
