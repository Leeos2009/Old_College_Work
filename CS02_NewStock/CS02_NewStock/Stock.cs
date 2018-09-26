using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace CS02_NewStock
{
    class Stock
    {
        // instance variables
        private int stock_No;
        private string description;
        private decimal cost_price;
        private decimal sale_price;
        private int qty;
        private char status;

        // no argument constructor
        public Stock()
        {
            stock_No = 0;
            description = "";
            cost_price = 0;
            sale_price = 0;
            qty = 0;

        }
        //Define setters
        public void setStockNo(int Stock_No)
        {
            this.stock_No = Stock_No;
        }
        public void setDescription(String Description)
        {
            this.description = Description;
        }

        public void setCostPrice(decimal Cost_Price)
        {
            this.cost_price = Cost_Price;
        }

        public void setSalePrice(decimal Sale_Price)
        {
            this.sale_price = Sale_Price;
        }

        public void setQty(int Qty)
        {
            this.qty = Qty;
        }

        public void setStatus(char Status)
        {
            this.status = Status;
        }

        //Define getters
        public int getStockNo()
        {
            return stock_No;
        }
      

        //define a static method to get data
        public static DataSet getAllStock(DataSet DS)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //connection name conn.Open();
            String strSQL = "SELECT StockNo, Description,Qty FROM Stock ORDER BY StockNo";
            OracleCommand cmd = new OracleCommand(strSQL, conn);
          
            //cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);

            da.Fill(DS, "ss");

            conn.Close();
     
            return DS;
        }

        public static int nextStockNo()
        {
            // variable to hold value to be returned
            int intNextStockNo;

            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL query to get MAX stock_No used
            String strSQL = "SELECT MAX(stockNo) FROM Stock";

            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            //execute the SQL query and put result in OracleDataReader object
            OracleDataReader dr = cmd.ExecuteReader();

            //read the first (only) value returned by query
            //If first stockNo, assign value 1, otherwise add 1 to MAX value
            dr.Read();

            //An aggregate function always returns 1 row, even if it contains a NULL value
            // If NULL, then there are no StockNo's in the Stock File - start at 1
            //Otherwise add 1 to the value read

            if (dr.IsDBNull(0))
                intNextStockNo = 1;
            else
                intNextStockNo = Convert.ToInt16(dr.GetValue(0)) + 1;

            //close DB connection
            myConn.Close();

            //return next StockNo
            return intNextStockNo;
        }

        public void regStock()
        {
            //connect to database
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL query to INSERT stock record
            String strSQL = "INSERT INTO Stock VALUES(" + this.stock_No.ToString() + 
                ",'" + this.description.ToUpper() + "'," + this.cost_price + "," +
                this.sale_price + "," + this.qty + ",'" + this.status + "')";
            
            //Execute the command
            OracleCommand cmd = new OracleCommand(strSQL, myConn);
            cmd.ExecuteNonQuery();

            //close DB connection
            myConn.Close();
        }

    }
}
