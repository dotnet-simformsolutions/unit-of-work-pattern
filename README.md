# Unit of Work Design Pattern with Repository pattern

- The Unit of Work Pattern in C# is used to group one or more operations (usually database CRUD operations) into a single transaction and execute them by applying the principle of do everything or do nothing. That means if any of the operations in the transaction failed, then it will roll back the transaction. If all the operations are successful, then it will commit the transaction. So, it will execute all the database operations as one unit.

- Repositories will generate and maintain their own instance of the DbContext. This may lead to issues in the future, since each DbContext will have its own in-memory list of changes of the records, of the entities, that are being added/updated/modified, in a single transaction/operation. In such a case, if the SaveChanges of one of the repository fails and other one succeeds, it will result in database in-consistency. This is where the concept of UnitOfWork is relevant.

- To avoid this, we will add another layer or intermediate between the controller and the Customer repository. This layer will act as a centralized store for all the repositories to receive the instance of the DbContext. This will ensure that, for a unit of transaction, that spans across multiple repositories, should either complete for all entities or should fail entirely, as all of them will share the same instance of the DbContext. In our above example, while adding data for the Order and Customer entities, in a single transaction, both will use the same DbContext instance. This situation, without and with Unit of work, can be represented as in the following :

  ![image](https://github.com/jil1710/readmedemo/assets/125335932/75aac976-8029-448e-b367-ce58e5970791)

- In the above representation, during a single operation, that involves Customer and Order entities, both of them use the same DbContext instance. This will ensure that even if one of them breaks, the other one is also not saved, thus maintaining the database consistency. So when SaveChanges is executed, it will be done for both of the repositories.

## Let's implement a generic repository for database operations using the Unit of Work pattern.

  - Create Unit of Work interface
    
    ![image](https://github.com/jil1710/readmedemo/assets/125335932/f44f442e-7e53-4e8f-8452-fcfc436ae600)

  - Implement the IUnitofWork interface that just created

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/df486036-c834-49df-9339-fc773738a05b)

  - Create generic repository interface

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/bd0e5acc-36af-437f-96cd-be1cded5f760)

  - Implement the generic IRepository

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/8b341495-aa97-4843-aa71-db50c9c3398c)

  - Register the Unit of Work as a service to use in a controller as DI injection

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/971da3cf-b4f4-40f9-ae54-b26773c835af)

  - Use IUnitOfWork interface in controller to perform transaction

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/1782effd-f6a8-4d30-b607-0b190f47e31f)

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/deec1683-4c90-45d6-91f0-2bea090e1978)

