# UI Updater Pattern
This repository show how to implement an asynchronous loading of data, as simple as possible.
The sample uses Windows Forms, but the basic p
![UiUpdaterPattern](https://github.com/user-attachments/assets/f8dbf9cd-d8ed-4bc5-8a04-ff74f6497264)

## Key elements:
The main method of 

```C#
    private async Task GetCustomersAsync()
    {
        try
        {
            btnGetCustomers.Enabled = false;
            await GetAndLoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnGetCustomers.Enabled = true;
        }
    }
```
