# UI Updater Pattern
This repository show how to implement an asynchronous loading of data, as simple as possible.

![UiUpdaterPattern](https://github.com/user-attachments/assets/f8dbf9cd-d8ed-4bc5-8a04-ff74f6497264)

The sample uses Windows Forms, but the basic pattern can be used in any paradigm.
When the update button (or any other UI control which initiates the async update) is activated:
1. Disable update button (to avoid reactivation while performing update)
2. Display a busy indicator (even just a "Working..." text in a statusbar/label/window titlebar)
3. Perform update in a try-catch
4. In the catch be ready to display an error message
5. In the finally:
    1. re-enable the update button 
    2. remove the busy indicator

# Key elements

## Basic update structure in C#
The main method of the windows form shows the 

```C#
    private async Task GetCustomersAsync()
    {
        try
        {
            btnGetCustomers.Enabled = false;                // 1) disable update buton
            btnGetCustomers.Text = "Retrieving data...";    // 2) display busy message
            await GetAndLoadData();                         // 3) perform update in try-catch
        }
        catch (Exception ex)
        {
            // 4) in the catch, be ready to show an error message
            MessageBox.Show($"An error occurred while loading data: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            // 5) In the finally 
            btnGetCustomers.Enabled = true; // re-enable the update button 
            btnGetCustomers.Text = "&Get Customers";    //remove the busy indicator
        }
    }
```
## BusyControlAnimator - helper class for animating text on controls
The BusyControlAnimator is used to toggle busy/idle status for a control, and displays an animated busy-indicator using text on the control, while it is busy.

### Usage
You pass the control you want to be able to toggle busy/idle status for to the constructor of the  BusyControlAnimator class:
```C#
BusyControlAnimator _busyIndicator = new BusyControlAnimator(btnGetCustomers);
```
When you want to set the busy/idle status of the control, you call

- SetBusy() - sets the control's Enabled property to false, and starts the busy-animation
- SetIdle() - sets the control's Enabled property to true, and stops the busy-animation
  
### Configurable elements
In the constructor you can pass 
- the text to display to signal "Busy" (default: "Working on it")
- the delay between animation updates (default: 150 ms)
If you want another animation, you can set the Animation property on the BusyControlAnimator (default:  { "◐", "◓", "◑", "◒" })  
Suggestions are:
 - { "⠋", "⠙", "⠹", "⠸", "⠼", "⠴", "⠦", "⠧", "⠇", "⠏" } //snake
-  { "◴", "◷", "◶", "◵" }   //clock
-  { "▖", "▘", "▝", "▗" }   //square

## Code sample - using the BusyControlAnimator
```C#
    private async Task GetCustomersAsync()
    {
        try
        {
            // 1 and 2 - sets the button to Enabled = false
            // and changes the text to "Retrieving data..."
            _busyIndicator.SetBusy(); 
            await GetAndLoadData();                         // 3) perform update in try-catch
        }
        catch (Exception ex)
        {
            // 4) in the catch, be ready to show an error message
            MessageBox.Show($"An error occurred while loading data: {ex.Message}", 
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        finally
        {
            // 5) In the finally 
            // sets the button back to Enabled and restores the original text
            _busyIndicator.SetIdle(); 
        }
    }
```
