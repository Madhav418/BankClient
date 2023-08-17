function printTable() {
    var transactionsDiv = document.getElementById('transactionsDiv');
    var table = document.getElementById('tdata');

    // Show the hidden div containing the table
    transactionsDiv.style.display = 'block';

    // Print the table
    var printWindow = window.open('', '', 'width=800,height=600');
    printWindow.document.write('<html><head><title>Transaction Details</title>');
    printWindow.document.write('<link rel="stylesheet" href="path_to_your_stylesheet.css" type="text/css" />');
    printWindow.document.write('</head><body>');
    printWindow.document.write(table.outerHTML);
    printWindow.document.write('</body></html>');
    printWindow.document.close();
    printWindow.print();

    // Hide the div again
    transactionsDiv.style.display = 'none';
}
