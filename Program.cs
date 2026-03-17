// See https://aka.ms/new-console-template for more information
using BookStore.Auth;
using BookStore.Serialize;
using BookStore.Services;
FileStorage fileStorage = new FileStorage();
Store store = new Store(fileStorage);
await store.Initialize();

