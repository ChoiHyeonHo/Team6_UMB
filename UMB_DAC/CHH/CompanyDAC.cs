using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO.CHH;

namespace UMB_DAC.CHH
{
    public class CompanyDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;
        public CompanyDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public List<CompanyVO> GetCompanyInfo()
        {
            string sql = @"select * from TBL_COMPANY where company_deleted = 'N'";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<CompanyVO> list = Helper.DataReaderMapToList<CompanyVO>(reader);
                return list;
            }
        }
        public List<CompanyTypeVO> GetCompanyType()
        {
            string sql = @"select common_id, common_name from TBL_COMMON_CODE where common_type = '업체구분'";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<CompanyTypeVO> list = Helper.DataReaderMapToList<CompanyTypeVO>(reader);
                return list;
            }
        }

        public bool Insert(CompanyVO vo)
        {
            string sql = @"insert into 
	                        TBL_COMPANY(company_name, company_type, company_ceo, company_cnum, company_btype, company_gtype, company_email, company_phone, 
                                        company_fax, company_ZipCode, company_Address, company_DetAddress, company_comment)
                            values (@company_name, @company_type, @company_ceo, @company_cnum, @company_btype, @company_gtype, @company_email, 
                                    @company_phone, @company_fax, @company_ZipCode, @company_Address, @company_DetAddress, @company_comment)";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@company_name", vo.company_name);
                cmd.Parameters.AddWithValue("@company_type", vo.company_type);
                cmd.Parameters.AddWithValue("@company_ceo", vo.company_ceo);
                cmd.Parameters.AddWithValue("@company_cnum", vo.company_cnum);
                cmd.Parameters.AddWithValue("@company_btype", vo.company_btype);
                cmd.Parameters.AddWithValue("@company_gtype", vo.company_gtype);
                cmd.Parameters.AddWithValue("@company_email", vo.company_email);
                cmd.Parameters.AddWithValue("@company_phone", vo.company_phone);
                cmd.Parameters.AddWithValue("@company_fax", vo.company_fax);
                cmd.Parameters.AddWithValue("@company_ZipCode", vo.company_ZipCode);
                cmd.Parameters.AddWithValue("@company_Address", vo.company_Address);
                cmd.Parameters.AddWithValue("@company_DetAddress", vo.company_DetAddress);
                cmd.Parameters.AddWithValue("@company_comment", vo.company_comment);

                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }
        public bool Update(CompanyVO vo)
        {
            string sql = @"update TBL_COMPANY 
                            set company_name = @company_name, 
	                            company_type = @company_type, 
	                            company_ceo = @company_ceo, 
	                            company_cnum = @company_cnum, 
	                            company_btype = @company_btype, 
	                            company_gtype = @company_gtype, 
	                            company_email = @company_email, 
	                            company_phone = @company_phone, 
	                            company_fax = @company_fax, 
	                            company_ZipCode = @company_ZipCode, 
	                            company_Address = @company_Address, 
	                            company_DetAddress = @company_DetAddress, 
	                            company_uadmin = @company_uadmin, 
	                            company_udate = @company_udate, 
	                            company_comment = @company_comment
                            where company_id = @company_id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@company_name", vo.company_name);
                cmd.Parameters.AddWithValue("@company_type", vo.company_type);
                cmd.Parameters.AddWithValue("@company_ceo", vo.company_ceo);
                cmd.Parameters.AddWithValue("@company_cnum", vo.company_cnum);
                cmd.Parameters.AddWithValue("@company_btype", vo.company_btype);
                cmd.Parameters.AddWithValue("@company_gtype", vo.company_gtype);
                cmd.Parameters.AddWithValue("@company_email", vo.company_email);
                cmd.Parameters.AddWithValue("@company_phone", vo.company_phone);
                cmd.Parameters.AddWithValue("@company_fax", vo.company_fax);
                cmd.Parameters.AddWithValue("@company_ZipCode", vo.company_ZipCode);
                cmd.Parameters.AddWithValue("@company_Address", vo.company_Address);
                cmd.Parameters.AddWithValue("@company_DetAddress", vo.company_DetAddress);
                cmd.Parameters.AddWithValue("@company_uadmin", vo.company_uadmin);
                cmd.Parameters.AddWithValue("@company_udate", vo.company_udate);
                cmd.Parameters.AddWithValue("@company_comment", vo.company_comment);
                cmd.Parameters.AddWithValue("@company_id", vo.company_id);

                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }

        public bool Delete(int ID)
        {
            string sql = @"update TBL_COMPANY 
                            set company_deleted = 'Y'
                            where company_id = @company_id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@company_id", ID);

                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }
        public List<CompanyVO> GetWhereInfo(string cbName, string cbType)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from TBL_COMPANY where company_deleted = 'N' and 1=1 ");
            if (cbName.Trim().Length > 0)
                sb.Append("and company_name = @company_name ");
            if (cbType.Trim().Length > 0)
                sb.Append("and company_type = @company_type ");

            string sql = sb.ToString();

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@company_name", cbName);
                cmd.Parameters.AddWithValue("@company_type", cbType);


                SqlDataReader reader = cmd.ExecuteReader();

                List<CompanyVO> list = Helper.DataReaderMapToList<CompanyVO>(reader);
                Dispose();

                return list;
            }
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
