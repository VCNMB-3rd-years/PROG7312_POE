# 🧩 PROG7312_POE – Community Service Request and Events App

## 📘 Project Overview

The Community Service Request and Events Application is a Windows Forms–based solution developed to help municipalities and residents efficiently manage and monitor service requests (e.g., potholes, power outages) and local community events/announcements.

It aims to enhance citizen engagement, municipal responsiveness, and community awareness through an intuitive interface and the use of advanced data structures for better data management, search, and recommendations.

# 🚀 Features Overview
## 🛠️ Core Features

Service Request Status Tracking
Submit, update, and view the current status of community service requests.

Local Events & Announcements
Browse, search, and sort community events by date, category, or name.

Smart Recommendations
Suggests relevant events to users based on their previous searches and interest patterns.
(Now dynamically generated using session-based tracking and cleared when the app closes.)

## 🧠 Data Structures Used and Their Roles
### 1. Dictionary / SortedDictionary

Used in: Local Events and Announcements

Purpose:
Efficiently stores and retrieves event data using a unique key (like event title or ID).

Benefits:

Enables O(1) average-time access to events.

Keeps data structured for fast searching, filtering, and sorting.

Example:

Dictionary<string, Event> eventsDictionary = new Dictionary<string, Event>();
eventsDictionary.Add("Community Cleanup", new Event("Cleanup Drive", "Environment", new DateTime(2025, 11, 12)));


This allows fast lookups like eventsDictionary["Community Cleanup"].

### 2. Stack / Queue / Priority Queue

Used in: Managing event submissions and user activity history

Purpose:

Queue: Manages incoming new event submissions in FIFO order for fair processing.

Stack: Stores “recently viewed” events so users can quickly revisit them (LIFO order).

Priority Queue (MinHeap): Prioritizes urgent or soonest events (by date).

Example:

Queue<Event> newEventQueue = new Queue<Event>();
newEventQueue.Enqueue(new Event("Water Repair", "Maintenance", DateTime.Now.AddDays(1)));


This ensures events are handled in the order they are received.

### 3. Set / HashSet

Used in: Managing unique categories and dates for filtering.

Purpose:
Ensures no duplicate event categories or dates are stored when filtering user searches.

Example:

HashSet<string> eventCategories = new HashSet<string>();
eventCategories.Add("Environment");
eventCategories.Add("Sports");


Prevents duplicates like adding "Environment" twice.

### 4. Binary Search Tree (BST)

Used in: Sorting and organizing event data by date or name.

Purpose:
Maintains sorted order dynamically as events are added.
Supports in-order traversal to list events chronologically.

Example:

BinarySearchTree<Event> eventTree = new BinarySearchTree<Event>();
eventTree.Insert(new Event("Tree Planting", "Environment", new DateTime(2025, 11, 20)));
var sortedEvents = eventTree.InOrder();


Returns all events in sorted order without manually sorting the list.

### 5. Graph (Adjacency List)

Used in: Recommendation System

Purpose:
Models relationships between categories (e.g., users who view “Sports” often may also like “Health” events).

Example:

graph.AddEdge("Sports", "Health");
graph.AddEdge("Environment", "Community");
var recommendations = graph.BFS("Sports");


Suggests related categories dynamically during browsing.

### 6. MinHeap (Priority Queue Implementation)

Used in: Prioritizing urgent service requests or upcoming events.

Purpose:
Always keeps the soonest or highest-priority item at the top for quick access.

Example:

MinHeap<Event> upcomingEvents = new MinHeap<Event>();
upcomingEvents.Add(new Event("Community Meeting", "Civic", new DateTime(2025, 11, 10)));
var nextEvent = upcomingEvents.Pop(); // Retrieves earliest event

## 💡 Recommendation Algorithm (Dynamic)

The recommendation algorithm dynamically tracks a user's searches and viewed categories during a session.

Data is stored in a Dictionary<string, int> (searchCount) that tracks how often each category or date is searched.

Recommendations are then generated using a Graph traversal (BFS) from the most-searched category.

When the app is closed or user navigates away, the data is cleared, ensuring privacy and fresh suggestions next session.

Example Workflow:

User searches “Sports” → searchCount["Sports"]++

Graph links “Sports” → “Health” → “Community”

Recommendations show “Health Fair” and “Community Walk”

On app shutdown → searchCount.Clear()

## ⚙️ How to Compile and Run
### 🧱 Prerequisites

Visual Studio 2022 or newer

.NET 6.0 or later

Windows OS (for WinForms support)

### 🪜 Steps to Run

Clone the repository:

git clone https://github.com/YourUsername/PROG7312_POE.git


Open the solution file in Visual Studio:

PROG7312_POE.sln


Set the startup project to:

PROG7312_POE


Build the project (Ctrl + Shift + B)

Run the application (F5)


## 🧭 How to Use

Main Menu → Navigate between:

- Service Request Page

= Local Events & Announcements

Recommendations

Exit

Events Page

Search by category or date

Sort by date/name/category

View recommendations based on previous searches

Service Request Page

Submit and monitor municipal service requests

View the status and expected resolution date

## 🧩 Improvements from Part 1 & 2
Area	Feedback from Part 2	Improvement in Part 3
Dictionaries	Only partially implemented	Fully integrated using Dictionary<string, Event> for event lookup
Sets	Missing or non-functional	Added HashSet for unique categories/dates
Recommendations	Static and inaccurate	Now dynamically tracks searches per session using a Graph and clears on exit
Smart Algorithm	No pattern tracking	Added searchCount tracking and BFS-based related category recommendations
Code Quality	Mixed structure	Refactored into Models/DataStructures and Services folders for modularity

## 🧾 Changelog
Version	Date	Update Summary
1.0	Part 1	Basic UI and service request form created
2.0	Part 2	Added Events page, implemented stacks & queues
3.0	Part 3	Introduced search-based recommendations, Sets, BST, and Graph structures; optimized event management
