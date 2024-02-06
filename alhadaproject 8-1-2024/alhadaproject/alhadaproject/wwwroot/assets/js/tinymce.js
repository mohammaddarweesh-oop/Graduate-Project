/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


tinymce.init({
    selector: 'textarea',
    menubar: false,
    directionality: "rtl",
    plugins: [
        'advlist autolink lists link  charmap print preview anchor',
        'searchreplace visualblocks code fullscreen',
        'insertdatetime  table contextmenu paste code',
        'directionality'
    ],
    toolbar: 'ltr rtl undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link ',

    content_css: [
        '//fonts.googleapis.com/css?family=Lato:300,300i,400,400i',
        '//www.tinymce.com/css/codepen.min.css'
    ]
});