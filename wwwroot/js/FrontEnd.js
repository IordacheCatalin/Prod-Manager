"use strict";
(function () {
    //Search function
    $(document).ready(function () {

        var appUrl = $("#appUrl").val();
  
        $('.slideBar-item.producManager-slideBar').click(function () {
       
            console.log("click")
            $('.slideBar-item.producManager-slideBar').removeClass("slideBar-item-active")
            $(this).addClass("slideBar-item-active");
        });
        
        //Show the sidebar containe
        $('#sidebarCollapse').on('click', function () {
            $('#sidebar').toggleClass('active');
        });
        
        $('#sidebarCollapse').click(function () {
            $('.navbar').toggleClass('slideBar-not-active');
            $('.modal.fade').toggleClass('slideBar-not-active');
            console.log('click')
        });
       
        PageName()
    });

    function PageName() {
        let pageName = $('.page-name').val();
        $('#Pagename').html(pageName);
    }

 
})();