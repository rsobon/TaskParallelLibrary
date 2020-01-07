# TaskParallelLibrary
Short demo on TPL and other .NET multithreading libraries

## What is TPL?

The Task Parallel Library (TPL) is a set of public types and APIs in the System.Threading and System.Threading.Tasks namespaces.

Starting with .NET 4 its preferred way for multithreaded code.

We already have:
- Threads
- Asynchronous Programming Mode (APM)
- Event-based Asynchronous Pattern (EAP)
- QueueUserWorkItem (ThreadPool)

**TPL is based on Task-based asynchronous pattern (TAP)**

## Threads

- Thread.Thread(ThreadStart start);
- ThreadStart is required method signature (void with no arguments).
  - Arguments have to be passed as boilerplate for ThreadStart method.
  - Results have to be processed as a event handlers.

## Asynchronous Programming Model (APM)

- Invoking delegate asynchronously (BeginInvoke, EndInvoke).
- IAsyncResult
  - AsyncWaitHandle.WaitOne();
  - IsCompleted
  - EndOperationName
  - AsyncCallback

## Event-based Asynchronous Pattern (EAP)

- BackgroundWorker class.
- Asynchronous operations are hooked up as event handlers such as:
  - DoWork
  - RunWorkerCompleted
- Signature of event handlers is forced.

## QueueUserWorkItem (ThreadPool)

- Scheduling work on ThreadPool.
- Results processed as event handlers.
- No built-int support for:
  - Synchronization between work items
  - Cancellation support
  - Exception handling

## Why TPL?

- Automatic scaling and scheduling work on the ThreadPool.
- Cancellation support.
- State management.
- Exception handling.
- Support for both async and parallel work.
- Task is awaitable (async/await keywords)

## Asynchronous vs Parallel

- Async
  - Executing in background
  - Responsiveness
  - e.g Doing other work when eggs are boiling
- Parallel
  - Executing simultaneously
  - Performance
  - e.g. Boiling multiple eggs simultaneously for performance
  
