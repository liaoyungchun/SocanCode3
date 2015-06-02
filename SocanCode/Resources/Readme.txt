SocanCode是一个能帮助.NET开发者自动生成代码，存储过程，用户控件等的工具，使用它可以省去众多繁琐的重复工作，让开发人员把精力集中在业务逻辑上,大量减少重复劳动

作者：廖勇军

软件功能及特点：

1、类反射工厂，泛型接口，三层架构，缓存机制，存储过程，分页，用户控件，一气呵成
2、支持SQLSERVER、ACCESS.
3、可选择简单三层架构和工厂模式三层架构
4、可选择不生成缓存代码、简单缓存对象、聚合缓存依赖
5、可选择要生成的层
6、可生成用户控件及后台代码
7、无需输入命令，即可为数据库，表启用缓存依赖
8、自动生成存储过程
9、数据库操作可选择SQL语句和存储过程
10、其它实用小工具

官方网站：http://www.Socansoft.com

配置说明:

1、简单缓存对象:一个数据库只在一个项目中使用的解决方案,生成的代码无缓存依赖
2、聚合缓存依赖:指一个数据库在多个项目中使用的解决方案,将生成三层结构,使用聚合缓存依赖,类似PetShop
3、命名空间前缀:不推荐,如果设置了命名空间前缀,并且使用的工厂模式三层结构或使用了聚合缓存依赖，请手动更改程序集名称
4、命名空间后缀:在一个项目中使用到多个库时,推荐设置为数据库名称,避免不同的数据库中有同名的表时产生冲突

特别说明：

1、如果使用了工厂模式三层结构，请在Web.config中设置项
    <add key="WebDAL" value="SQLServerDAL"/>

2、如果使用了缓存，请在Web.config中设置项，指示是否启用缓存。不加此项，相当于不使用缓存
    <add key="EnableCache" value="true"/>

3、如果使用了聚合缓存依赖，请在Web.config的appSettings节点中设置项
    <add key="CacheDependencyAssembly" value="TableCacheDependency"/>-->

   在system.web节点中设置
    <caching>
      <sqlCacheDependency enabled="true" pollTime="1000">
        <databases>
          <!--
            这里配置缓存依赖数据库的连接，
            如果库名填写与实际的库名不正确的话
            会出现"调用的目标发生异常"的错误
          -->          
          <add name="database" connectionStringName="ConnectionString"/>
        </databases>
      </sqlCacheDependency>
    </caching>

  在数据库上点右键，选择“为Sql依赖缓存启用数据库”，在“表”上点右键选择为“Sql依赖缓存启用所有表”。