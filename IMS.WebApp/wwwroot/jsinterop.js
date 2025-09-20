function preventFormSubmission(formId) {

    document.getElementById(`${formId}`).addEventListener('keydown', function (event) {

        // Check if the pressed key is Enter
        if (event.key === 'Enter') {
            event.preventDefault(); // Prevent the default form submission behavior
            return false; // Return false to indicate that the event has been handled
        }
    });
}