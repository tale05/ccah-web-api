----database first, xong vào tool chạy:
Scaffold-DbContext "Data Source=.;Initial Catalog=IRT;Persist Security Info=True;User ID=sa;Password=123;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Entities
    
Scaffold-DbContext "Data Source=.\\MSSQLSERVER2019;Initial Catalog=cca86170_IRT;Persist Security Info=True;User ID=cca86170_IRT;Password=irtHUFI@01;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Entities -f

Scaffold-DbContext "Data Source=112.78.2.206;Initial Catalog=cca86170_IRT;Persist Security Info=True;User ID=cca86170_IRT;Password=irtCCAHedu@@;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Entities -f

-- để generate lại thì gõ -f