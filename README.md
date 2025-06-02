# PortfolioTeacher

## Preparing for running

1. Install Minio Server from [Minio Windows](https://min.io/open-source/download?platform=windows)
2. Install Redis Server on WSL under Ubuntu
```
sudo apt-get update
sudo apt-get install redis

sudo service redis-server start
```
3. Check access to database server MySQL
4. Create secrets file for API & ID Projects
5. in secret API write
```
{
	"DBHost": "YourDatabaseUser",
	"DBPassword": "YourDatabasePassword",
	"Minio": {
		"AccessKey": "minioadmin",
		"SecretKey": "minioadmin"
	}
}
```
6. in secret ID write
```
{
	"DBHost": "YourDatabaseUser",
	"DBPassword": "YourDatabasePassword"
}
```