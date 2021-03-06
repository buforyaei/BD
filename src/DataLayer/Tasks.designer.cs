﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Serwis")]
	public partial class TasksDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertProblem(Problem instance);
    partial void UpdateProblem(Problem instance);
    partial void DeleteProblem(Problem instance);
    partial void InsertObject(Object instance);
    partial void UpdateObject(Object instance);
    partial void DeleteObject(Object instance);
    partial void InsertPerson(Person instance);
    partial void UpdatePerson(Person instance);
    partial void DeletePerson(Person instance);
    partial void InsertClient(Client instance);
    partial void UpdateClient(Client instance);
    partial void DeleteClient(Client instance);
    partial void InsertEmployee(Employee instance);
    partial void UpdateEmployee(Employee instance);
    partial void DeleteEmployee(Employee instance);
    #endregion
		
		public TasksDataContext() : 
				base(global::DataLayer.Properties.Settings.Default.SerwisConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public TasksDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TasksDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TasksDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TasksDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Problem> Problems
		{
			get
			{
				return this.GetTable<Problem>();
			}
		}
		
		public System.Data.Linq.Table<Object> Objects
		{
			get
			{
				return this.GetTable<Object>();
			}
		}
		
		public System.Data.Linq.Table<Object_type> Object_types
		{
			get
			{
				return this.GetTable<Object_type>();
			}
		}
		
		public System.Data.Linq.Table<Task> Tasks
		{
			get
			{
				return this.GetTable<Task>();
			}
		}
		
		public System.Data.Linq.Table<Task_type> Task_types
		{
			get
			{
				return this.GetTable<Task_type>();
			}
		}
		
		public System.Data.Linq.Table<Person> Persons
		{
			get
			{
				return this.GetTable<Person>();
			}
		}
		
		public System.Data.Linq.Table<Client> Clients
		{
			get
			{
				return this.GetTable<Client>();
			}
		}
		
		public System.Data.Linq.Table<Employee> Employees
		{
			get
			{
				return this.GetTable<Employee>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Problem")]
	public partial class Problem : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _problemID;
		
		private string _problemDesc;
		
		private string _resultDesc;
		
		private System.Nullable<System.DateTime> _beginDate;
		
		private System.Nullable<System.DateTime> _endDate;
		
		private System.Nullable<int> _objectID;
		
		private EntityRef<Object> _Object;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnproblemIDChanging(int value);
    partial void OnproblemIDChanged();
    partial void OnproblemDescChanging(string value);
    partial void OnproblemDescChanged();
    partial void OnresultDescChanging(string value);
    partial void OnresultDescChanged();
    partial void OnbeginDateChanging(System.Nullable<System.DateTime> value);
    partial void OnbeginDateChanged();
    partial void OnendDateChanging(System.Nullable<System.DateTime> value);
    partial void OnendDateChanged();
    partial void OnobjectIDChanging(System.Nullable<int> value);
    partial void OnobjectIDChanged();
    #endregion
		
		public Problem()
		{
			this._Object = default(EntityRef<Object>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_problemID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int problemID
		{
			get
			{
				return this._problemID;
			}
			set
			{
				if ((this._problemID != value))
				{
					this.OnproblemIDChanging(value);
					this.SendPropertyChanging();
					this._problemID = value;
					this.SendPropertyChanged("problemID");
					this.OnproblemIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_problemDesc", DbType="VarChar(50)")]
		public string problemDesc
		{
			get
			{
				return this._problemDesc;
			}
			set
			{
				if ((this._problemDesc != value))
				{
					this.OnproblemDescChanging(value);
					this.SendPropertyChanging();
					this._problemDesc = value;
					this.SendPropertyChanged("problemDesc");
					this.OnproblemDescChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_resultDesc", DbType="VarChar(50)")]
		public string resultDesc
		{
			get
			{
				return this._resultDesc;
			}
			set
			{
				if ((this._resultDesc != value))
				{
					this.OnresultDescChanging(value);
					this.SendPropertyChanging();
					this._resultDesc = value;
					this.SendPropertyChanged("resultDesc");
					this.OnresultDescChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_beginDate", DbType="Date")]
		public System.Nullable<System.DateTime> beginDate
		{
			get
			{
				return this._beginDate;
			}
			set
			{
				if ((this._beginDate != value))
				{
					this.OnbeginDateChanging(value);
					this.SendPropertyChanging();
					this._beginDate = value;
					this.SendPropertyChanged("beginDate");
					this.OnbeginDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_endDate", DbType="Date")]
		public System.Nullable<System.DateTime> endDate
		{
			get
			{
				return this._endDate;
			}
			set
			{
				if ((this._endDate != value))
				{
					this.OnendDateChanging(value);
					this.SendPropertyChanging();
					this._endDate = value;
					this.SendPropertyChanged("endDate");
					this.OnendDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_objectID", DbType="Int")]
		public System.Nullable<int> objectID
		{
			get
			{
				return this._objectID;
			}
			set
			{
				if ((this._objectID != value))
				{
					if (this._Object.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnobjectIDChanging(value);
					this.SendPropertyChanging();
					this._objectID = value;
					this.SendPropertyChanged("objectID");
					this.OnobjectIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Object_Problem", Storage="_Object", ThisKey="objectID", OtherKey="objectID", IsForeignKey=true)]
		public Object Object
		{
			get
			{
				return this._Object.Entity;
			}
			set
			{
				Object previousValue = this._Object.Entity;
				if (((previousValue != value) 
							|| (this._Object.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Object.Entity = null;
						previousValue.Problems.Remove(this);
					}
					this._Object.Entity = value;
					if ((value != null))
					{
						value.Problems.Add(this);
						this._objectID = value.objectID;
					}
					else
					{
						this._objectID = default(Nullable<int>);
					}
					this.SendPropertyChanged("Object");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Object")]
	public partial class Object : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _objectID;
		
		private System.Nullable<int> _clientID;
		
		private EntitySet<Problem> _Problems;
		
		private EntityRef<Client> _Client;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnobjectIDChanging(int value);
    partial void OnobjectIDChanged();
    partial void OnclientIDChanging(System.Nullable<int> value);
    partial void OnclientIDChanged();
    #endregion
		
		public Object()
		{
			this._Problems = new EntitySet<Problem>(new Action<Problem>(this.attach_Problems), new Action<Problem>(this.detach_Problems));
			this._Client = default(EntityRef<Client>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_objectID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int objectID
		{
			get
			{
				return this._objectID;
			}
			set
			{
				if ((this._objectID != value))
				{
					this.OnobjectIDChanging(value);
					this.SendPropertyChanging();
					this._objectID = value;
					this.SendPropertyChanged("objectID");
					this.OnobjectIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_clientID", DbType="Int")]
		public System.Nullable<int> clientID
		{
			get
			{
				return this._clientID;
			}
			set
			{
				if ((this._clientID != value))
				{
					if (this._Client.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnclientIDChanging(value);
					this.SendPropertyChanging();
					this._clientID = value;
					this.SendPropertyChanged("clientID");
					this.OnclientIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Object_Problem", Storage="_Problems", ThisKey="objectID", OtherKey="objectID")]
		public EntitySet<Problem> Problems
		{
			get
			{
				return this._Problems;
			}
			set
			{
				this._Problems.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Client_Object", Storage="_Client", ThisKey="clientID", OtherKey="clientID", IsForeignKey=true)]
		public Client Client
		{
			get
			{
				return this._Client.Entity;
			}
			set
			{
				Client previousValue = this._Client.Entity;
				if (((previousValue != value) 
							|| (this._Client.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Client.Entity = null;
						previousValue.Objects.Remove(this);
					}
					this._Client.Entity = value;
					if ((value != null))
					{
						value.Objects.Add(this);
						this._clientID = value.clientID;
					}
					else
					{
						this._clientID = default(Nullable<int>);
					}
					this.SendPropertyChanged("Client");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Problems(Problem entity)
		{
			this.SendPropertyChanging();
			entity.Object = this;
		}
		
		private void detach_Problems(Problem entity)
		{
			this.SendPropertyChanging();
			entity.Object = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[Object type]")]
	public partial class Object_type
	{
		
		private System.Nullable<int> _code;
		
		private string _name;
		
		public Object_type()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_code", DbType="Int")]
		public System.Nullable<int> code
		{
			get
			{
				return this._code;
			}
			set
			{
				if ((this._code != value))
				{
					this._code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this._name = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Task")]
	public partial class Task
	{
		
		private int _taskID;
		
		private string _status;
		
		private string _taskDesc;
		
		private string _resultDesc;
		
		private System.Nullable<System.DateTime> _beginDate;
		
		private System.Nullable<System.DateTime> _endDate;
		
		private System.Nullable<int> _problemID;
		
		private System.Nullable<int> _employID;
		
		public Task()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_taskID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int taskID
		{
			get
			{
				return this._taskID;
			}
			set
			{
				if ((this._taskID != value))
				{
					this._taskID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status", DbType="VarChar(50)")]
		public string status
		{
			get
			{
				return this._status;
			}
			set
			{
				if ((this._status != value))
				{
					this._status = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_taskDesc", DbType="VarChar(50)")]
		public string taskDesc
		{
			get
			{
				return this._taskDesc;
			}
			set
			{
				if ((this._taskDesc != value))
				{
					this._taskDesc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_resultDesc", DbType="VarChar(50)")]
		public string resultDesc
		{
			get
			{
				return this._resultDesc;
			}
			set
			{
				if ((this._resultDesc != value))
				{
					this._resultDesc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_beginDate", DbType="Date")]
		public System.Nullable<System.DateTime> beginDate
		{
			get
			{
				return this._beginDate;
			}
			set
			{
				if ((this._beginDate != value))
				{
					this._beginDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_endDate", DbType="Date")]
		public System.Nullable<System.DateTime> endDate
		{
			get
			{
				return this._endDate;
			}
			set
			{
				if ((this._endDate != value))
				{
					this._endDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_problemID", DbType="Int")]
		public System.Nullable<int> problemID
		{
			get
			{
				return this._problemID;
			}
			set
			{
				if ((this._problemID != value))
				{
					this._problemID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_employID", DbType="Int")]
		public System.Nullable<int> employID
		{
			get
			{
				return this._employID;
			}
			set
			{
				if ((this._employID != value))
				{
					this._employID = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[Task type]")]
	public partial class Task_type
	{
		
		private System.Nullable<int> _code;
		
		private string _name;
		
		public Task_type()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_code", DbType="Int")]
		public System.Nullable<int> code
		{
			get
			{
				return this._code;
			}
			set
			{
				if ((this._code != value))
				{
					this._code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this._name = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Person")]
	public partial class Person : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _name;
		
		private string _surname;
		
		private string _address;
		
		private System.Nullable<int> _phone;
		
		private int _personID;
		
		private EntitySet<Client> _Clients;
		
		private EntitySet<Employee> _Employees;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnsurnameChanging(string value);
    partial void OnsurnameChanged();
    partial void OnaddressChanging(string value);
    partial void OnaddressChanged();
    partial void OnphoneChanging(System.Nullable<int> value);
    partial void OnphoneChanged();
    partial void OnpersonIDChanging(int value);
    partial void OnpersonIDChanged();
    #endregion
		
		public Person()
		{
			this._Clients = new EntitySet<Client>(new Action<Client>(this.attach_Clients), new Action<Client>(this.detach_Clients));
			this._Employees = new EntitySet<Employee>(new Action<Employee>(this.attach_Employees), new Action<Employee>(this.detach_Employees));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_surname", DbType="VarChar(50)")]
		public string surname
		{
			get
			{
				return this._surname;
			}
			set
			{
				if ((this._surname != value))
				{
					this.OnsurnameChanging(value);
					this.SendPropertyChanging();
					this._surname = value;
					this.SendPropertyChanged("surname");
					this.OnsurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address", DbType="VarChar(50)")]
		public string address
		{
			get
			{
				return this._address;
			}
			set
			{
				if ((this._address != value))
				{
					this.OnaddressChanging(value);
					this.SendPropertyChanging();
					this._address = value;
					this.SendPropertyChanged("address");
					this.OnaddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone", DbType="Int")]
		public System.Nullable<int> phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				if ((this._phone != value))
				{
					this.OnphoneChanging(value);
					this.SendPropertyChanging();
					this._phone = value;
					this.SendPropertyChanged("phone");
					this.OnphoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_personID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int personID
		{
			get
			{
				return this._personID;
			}
			set
			{
				if ((this._personID != value))
				{
					this.OnpersonIDChanging(value);
					this.SendPropertyChanging();
					this._personID = value;
					this.SendPropertyChanged("personID");
					this.OnpersonIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Person_Client", Storage="_Clients", ThisKey="personID", OtherKey="personID")]
		public EntitySet<Client> Clients
		{
			get
			{
				return this._Clients;
			}
			set
			{
				this._Clients.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Person_Employee", Storage="_Employees", ThisKey="personID", OtherKey="personID")]
		public EntitySet<Employee> Employees
		{
			get
			{
				return this._Employees;
			}
			set
			{
				this._Employees.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Clients(Client entity)
		{
			this.SendPropertyChanging();
			entity.Person = this;
		}
		
		private void detach_Clients(Client entity)
		{
			this.SendPropertyChanging();
			entity.Person = null;
		}
		
		private void attach_Employees(Employee entity)
		{
			this.SendPropertyChanging();
			entity.Person = this;
		}
		
		private void detach_Employees(Employee entity)
		{
			this.SendPropertyChanging();
			entity.Person = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Client")]
	public partial class Client : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _clientID;
		
		private System.Nullable<int> _personID;
		
		private EntitySet<Object> _Objects;
		
		private EntityRef<Person> _Person;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnclientIDChanging(int value);
    partial void OnclientIDChanged();
    partial void OnpersonIDChanging(System.Nullable<int> value);
    partial void OnpersonIDChanged();
    #endregion
		
		public Client()
		{
			this._Objects = new EntitySet<Object>(new Action<Object>(this.attach_Objects), new Action<Object>(this.detach_Objects));
			this._Person = default(EntityRef<Person>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_clientID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int clientID
		{
			get
			{
				return this._clientID;
			}
			set
			{
				if ((this._clientID != value))
				{
					this.OnclientIDChanging(value);
					this.SendPropertyChanging();
					this._clientID = value;
					this.SendPropertyChanged("clientID");
					this.OnclientIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_personID", DbType="Int")]
		public System.Nullable<int> personID
		{
			get
			{
				return this._personID;
			}
			set
			{
				if ((this._personID != value))
				{
					if (this._Person.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnpersonIDChanging(value);
					this.SendPropertyChanging();
					this._personID = value;
					this.SendPropertyChanged("personID");
					this.OnpersonIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Client_Object", Storage="_Objects", ThisKey="clientID", OtherKey="clientID")]
		public EntitySet<Object> Objects
		{
			get
			{
				return this._Objects;
			}
			set
			{
				this._Objects.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Person_Client", Storage="_Person", ThisKey="personID", OtherKey="personID", IsForeignKey=true)]
		public Person Person
		{
			get
			{
				return this._Person.Entity;
			}
			set
			{
				Person previousValue = this._Person.Entity;
				if (((previousValue != value) 
							|| (this._Person.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Person.Entity = null;
						previousValue.Clients.Remove(this);
					}
					this._Person.Entity = value;
					if ((value != null))
					{
						value.Clients.Add(this);
						this._personID = value.personID;
					}
					else
					{
						this._personID = default(Nullable<int>);
					}
					this.SendPropertyChanged("Person");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Objects(Object entity)
		{
			this.SendPropertyChanging();
			entity.Client = this;
		}
		
		private void detach_Objects(Object entity)
		{
			this.SendPropertyChanging();
			entity.Client = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Employees")]
	public partial class Employee : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _employID;
		
		private string _username;
		
		private string _password;
		
		private string _role;
		
		private System.Nullable<int> _personID;
		
		private EntityRef<Person> _Person;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnemployIDChanging(int value);
    partial void OnemployIDChanged();
    partial void OnusernameChanging(string value);
    partial void OnusernameChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    partial void OnroleChanging(string value);
    partial void OnroleChanged();
    partial void OnpersonIDChanging(System.Nullable<int> value);
    partial void OnpersonIDChanged();
    #endregion
		
		public Employee()
		{
			this._Person = default(EntityRef<Person>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_employID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int employID
		{
			get
			{
				return this._employID;
			}
			set
			{
				if ((this._employID != value))
				{
					this.OnemployIDChanging(value);
					this.SendPropertyChanging();
					this._employID = value;
					this.SendPropertyChanged("employID");
					this.OnemployIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_username", DbType="VarChar(50)")]
		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				if ((this._username != value))
				{
					this.OnusernameChanging(value);
					this.SendPropertyChanging();
					this._username = value;
					this.SendPropertyChanged("username");
					this.OnusernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="VarChar(50)")]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_role", DbType="NChar(10)")]
		public string role
		{
			get
			{
				return this._role;
			}
			set
			{
				if ((this._role != value))
				{
					this.OnroleChanging(value);
					this.SendPropertyChanging();
					this._role = value;
					this.SendPropertyChanged("role");
					this.OnroleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_personID", DbType="Int")]
		public System.Nullable<int> personID
		{
			get
			{
				return this._personID;
			}
			set
			{
				if ((this._personID != value))
				{
					if (this._Person.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnpersonIDChanging(value);
					this.SendPropertyChanging();
					this._personID = value;
					this.SendPropertyChanged("personID");
					this.OnpersonIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Person_Employee", Storage="_Person", ThisKey="personID", OtherKey="personID", IsForeignKey=true)]
		public Person Person
		{
			get
			{
				return this._Person.Entity;
			}
			set
			{
				Person previousValue = this._Person.Entity;
				if (((previousValue != value) 
							|| (this._Person.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Person.Entity = null;
						previousValue.Employees.Remove(this);
					}
					this._Person.Entity = value;
					if ((value != null))
					{
						value.Employees.Add(this);
						this._personID = value.personID;
					}
					else
					{
						this._personID = default(Nullable<int>);
					}
					this.SendPropertyChanged("Person");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
