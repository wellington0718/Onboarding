
window.ClientExporter = {

    generatePDF: async function (view) {

        var html = document.querySelector("#itemToExport");
        var viwer = document.querySelector("#viwer");

        var opt = {
            margin: 0.2,
            pagebreak: { mode: 'avoid-all' },
            image: { type: 'jpeg', quality: 0.98 },
            html2canvas: { scale: 3 },
            jsPDF: { unit: 'in', format: "a3", orientation: 'portrait' }
        };

        if (!view) {
            var worker = html2pdf().set(opt).from(html).toPdf().get('pdf').then(function (pdf) {
                window.open(pdf.output('bloburl'), '_blank');
            });
        }
        else {
            html2pdf().set(opt).from(html).outputImg("datauristring").then(function (data) {
                viwer.src = data;
            })
        }

    },

    scrollTop: async function (element) {

        if (element) {
            let scrollTopBtn = document.querySelector(element)
            scrollTopBtn.addEventListener("click", function () {
                let layout = document.querySelector("#radzenBody");
                layout.scrollTo({ "top": "0", "behavior": "smooth" });
            });
        }
        else {
            let layout = document.querySelector("#radzenBody");
            layout.scrollTo({ "top": "0", "behavior": "smooth" });

        }
    }
}

